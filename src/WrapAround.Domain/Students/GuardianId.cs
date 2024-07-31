namespace WrapAround.Domain.Students;

public record struct GuardianId(Guid Value)
{
    public static GuardianId Create(Guid id)
    {
        return new GuardianId(id);
    }

    public static GuardianId CreateUnique()
    {
        return new GuardianId(Guid.NewGuid());
    }
};
