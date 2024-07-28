using WrapAround.Domain.Common.Models;
using WrapAround.Domain.School;

namespace WrapAround.Domain.Sessions;

public class Session : AggregateRoot<SessionId>
{
    private readonly List<Student> _attendees = [];

    public IReadOnlyCollection<Student> Attendees
        => _attendees;

    // TODO: Start + End Or Start + Duration?

    private Session(SessionId id)
        : base(id)
    {
    }

    public static Session Create()
    {
        return new(SessionId.CreateUnique());
    }

    // TODO: ErrorOr
    // TODO: Parameter Student or StudentId?
    public void AddStudent(Student student)
    {
        // TODO: Error if student already added
        _attendees.Add(student);
        // TODO: Domain event for student added to session
    }

    public void RemoveStudent(Student student)
    {
        _attendees.Remove(student);
        // TODO: Domain event for student removed from session
    }
}
