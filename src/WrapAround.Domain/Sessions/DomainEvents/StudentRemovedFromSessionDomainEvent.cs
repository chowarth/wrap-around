using WrapAround.Domain.Common.Events;
using WrapAround.Domain.Students;

namespace WrapAround.Domain.Sessions.DomainEvents;

public sealed class StudentRemovedFromSessionDomainEvent : IDomainEvent
{
    public StudentId StudentId { get; }

    internal StudentRemovedFromSessionDomainEvent(StudentId studentId)
    {
        StudentId = studentId;
    }
}
