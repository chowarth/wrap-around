using WrapAround.Domain.Common.Models;

namespace WrapAround.Domain.School;

public class StudentId : ValueObject
{
    public Guid Value { get; }

    private StudentId(Guid value)
    {
        Value = value;
    }

    public static StudentId Create(Guid id)
    {
        return new StudentId(id);
    }

    public static StudentId CreateUnique()
    {
        return new StudentId(Guid.NewGuid());
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
