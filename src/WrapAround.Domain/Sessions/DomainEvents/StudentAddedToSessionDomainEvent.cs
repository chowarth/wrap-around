using WrapAround.Domain.Common.Events;
using WrapAround.Domain.Students;

namespace WrapAround.Domain.Sessions.DomainEvents;

public sealed class StudentAddedToSessionDomainEvent : IDomainEvent
{
    public StudentId StudentId { get; }

    internal StudentAddedToSessionDomainEvent(StudentId studentId)
    {
        StudentId = studentId;
    }
}
