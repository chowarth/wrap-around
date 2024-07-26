using WrapAround.Domain.Common.Events;

namespace WrapAround.Domain.Common.Models;

public abstract class AggregateRoot<TId> : Entity<TId>
    where TId : notnull
{
    private readonly List<IDomainEvent> _domainEvents = [];

    public IReadOnlyCollection<IDomainEvent> DomainEvents
        => _domainEvents.AsReadOnly();

    protected AggregateRoot(TId id)
        : base(id)
    {
    }

    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }

    protected void AddDomainEvent(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }
}
