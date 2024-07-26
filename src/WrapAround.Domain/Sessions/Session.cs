using WrapAround.Domain.Common.Models;

namespace WrapAround.Domain.Sessions;

public class Session : AggregateRoot
{
    public List<string> Attendees { get; set; } = new ();

    public Session(Guid id)
        : base(id)
    {
    }
}
