using MediatR;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using WrapAround.Application.Common.Persistence;
using WrapAround.Domain.Common.Events;
using WrapAround.Domain.Common.Models;

namespace WrapAround.Infrastructure.Common.Persistence;

internal sealed class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IMediator _mediator;

    public UnitOfWork(ApplicationDbContext dbContext, IMediator mediator)
    {
        _dbContext = dbContext;
        _mediator = mediator;
    }

    /// <inheritdoc/>
    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        // UnitOfWork can be expanded, if needed, to include things like:
        // Updating auditable entities i.e. When an entity was created or modified

        await PublishDomainEvents(cancellationToken);

        return await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task PublishDomainEvents(CancellationToken cancellationToken)
    {
        List<EntityEntry<IAggregateRoot>> aggregateRoots = _dbContext.ChangeTracker
            .Entries<IAggregateRoot>()
            .Where(entry => entry.Entity.DomainEvents.Any())
            .ToList();

        List<IDomainEvent> domainEvents = aggregateRoots
            .SelectMany(entry => entry.Entity.DomainEvents).ToList();

        aggregateRoots.ForEach(entry => entry.Entity.ClearDomainEvents());

        IEnumerable<Task> publishTasks = domainEvents
            .Select(domainEvent => _mediator.Publish(domainEvent, cancellationToken));

        await Task.WhenAll(publishTasks);
    }
}
