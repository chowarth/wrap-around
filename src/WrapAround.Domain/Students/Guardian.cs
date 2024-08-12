using WrapAround.Domain.Common.Models;

namespace WrapAround.Domain.Students;

public sealed class Guardian : Entity<GuardianId>
{
    private readonly List<PhoneNumber> _phoneNumbers = [];

    public string FirstName { get; }
    public string LastName { get; }
    public string Email { get; }
    public Address? Address { get; private set; }
    public IReadOnlyCollection<PhoneNumber> PhoneNumbers
        => _phoneNumbers;

    private Guardian(GuardianId id, string firstName, string lastName, string email)
        : base(id)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
    }

    public static Guardian Create(string firstName, string lastName, string email)
    {
        return new Guardian(GuardianId.CreateUnique(), firstName, lastName, email);
    }
}
