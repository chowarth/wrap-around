using WrapAround.Domain.Common.Models;

namespace WrapAround.Domain.Sessions;

// Should ID's be a readonly record struct?
public sealed class SessionId : ValueObject
{
    public Guid Value { get; }

    private SessionId(Guid value)
    {
        Value = value;
    }

    public static SessionId Create(Guid id)
    {
        return new SessionId(id);
    }

    public static SessionId CreateUnique()
    {
        return new SessionId(Guid.NewGuid());
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
