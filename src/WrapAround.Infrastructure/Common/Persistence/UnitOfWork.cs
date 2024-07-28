using WrapAround.Application.Common.Persistence;

namespace WrapAround.Infrastructure.Common.Persistence;

internal sealed class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _dbContext;

    public UnitOfWork(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    /// <inheritdoc/>
    public Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        // UnitOfWork can be expanded, if needed, to include things like:
        // Publishing of domain events
        // Updating auditable entities i.e. When an entity was created or modified
        return _dbContext.SaveChangesAsync(cancellationToken);
    }
}
