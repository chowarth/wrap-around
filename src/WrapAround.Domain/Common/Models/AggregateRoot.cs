using WrapAround.Domain.Common.Events;

namespace WrapAround.Domain.Common.Models;

public interface IAggregateRoot
{
    IReadOnlyCollection<IDomainEvent> DomainEvents { get; }

    void ClearDomainEvents();
}

public abstract class AggregateRoot<TId> : Entity<TId>, IAggregateRoot
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
