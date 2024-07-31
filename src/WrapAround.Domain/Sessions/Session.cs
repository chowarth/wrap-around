using ErrorOr;
using WrapAround.Domain.Common.Models;
using WrapAround.Domain.Sessions.DomainEvents;
using WrapAround.Domain.Students;

namespace WrapAround.Domain.Sessions;

public sealed class Session : AggregateRoot<SessionId>
{
    // TODO: How to configure the relationship between Session and Student?
    //private readonly List<StudentId> _studentsIds = [];

    //public IReadOnlyCollection<StudentId> StudentsIds
    //    => _studentsIds;

    public DateOnly Date { get; }

    public TimeOnly StartTime { get; }

    public TimeOnly EndTime { get; }

    private Session(SessionId id)
        : base(id)
    {
    }

    public static Session Create()
    {
        var session = new Session(SessionId.CreateUnique());
        session.AddDomainEvent(new SessionCreatedDomainEvent(session));

        return session;
    }

    //public ErrorOr<Success> AddStudent(StudentId student)
    //{
    //    if (_studentsIds.Contains(student))
    //    {
    //        return Error.Conflict(description: "Student already added to session");
    //    }

    //    _studentsIds.Add(student);
    //    AddDomainEvent(new StudentAddedToSessionDomainEvent(student));

    //    return Result.Success;
    //}

    //public void RemoveStudent(StudentId student)
    //{
    //    if (_studentsIds.Remove(student))
    //    {
    //        AddDomainEvent(new StudentRemovedFromSessionDomainEvent(student));
    //    }
    //}
}
