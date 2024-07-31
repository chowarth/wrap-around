using WrapAround.Domain.Common.Events;
using WrapAround.Domain.Students;

namespace WrapAround.Domain.Sessions.DomainEvents;

public sealed class StudentRemovedFromSessionDomainEvent : IDomainEvent
{
    public Student Student { get; }

    internal StudentRemovedFromSessionDomainEvent(Student student)
    {
        Student = student;
    }
}
