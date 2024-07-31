using ErrorOr;
using WrapAround.Domain.Common.Models;
using WrapAround.Domain.Sessions.DomainEvents;
using WrapAround.Domain.Students;

namespace WrapAround.Domain.Sessions;

public sealed class Session : AggregateRoot<SessionId>
{
    private readonly List<Student> _students = [];

    public IReadOnlyCollection<Student> Students
        => _students;

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

    public ErrorOr<Success> AddStudent(Student student)
    {
        if (_students.Contains(student))
        {
            return Error.Conflict(description: "Student already added to session");
        }

        _students.Add(student);
        AddDomainEvent(new StudentAddedToSessionDomainEvent(student));

        return Result.Success;
    }

    public void RemoveStudent(Student student)
    {
        if (_students.Remove(student))
        {
            AddDomainEvent(new StudentRemovedFromSessionDomainEvent(student));
        }
    }
}
