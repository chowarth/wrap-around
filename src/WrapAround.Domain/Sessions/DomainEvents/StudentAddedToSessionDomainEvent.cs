using WrapAround.Domain.Common.Events;

namespace WrapAround.Domain.Sessions.DomainEvents;

public sealed class StudentAddedToSessionDomainEvent : IDomainEvent
{
    public Student Student { get; }

    internal StudentAddedToSessionDomainEvent(Student student)
    {
        Student = student;
    }
}
