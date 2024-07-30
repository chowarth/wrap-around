using WrapAround.Domain.Common.Events;

namespace WrapAround.Domain.Sessions.DomainEvents;

public sealed class SessionCreatedDomainEvent : IDomainEvent
{
    public Session Session { get; }

    public SessionCreatedDomainEvent(Session session)
    {
        Session = session;
    }
}
