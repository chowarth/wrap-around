using WrapAround.Domain.Common.Models;

namespace WrapAround.Domain.Sessions;

public class Session : AggregateRoot<SessionId>
{
    private readonly List<string> _attendees = [];

    public IReadOnlyCollection<string> Attendees
        => _attendees.AsReadOnly();

    private Session(SessionId id)
        : base(id)
    {
    }

    public static Session Create()
    {
        return new(SessionId.CreateUnique());
    }
}
