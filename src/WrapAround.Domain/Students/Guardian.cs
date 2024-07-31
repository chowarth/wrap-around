using WrapAround.Domain.Common.Models;

namespace WrapAround.Domain.Students;

public sealed class Guardian : Entity<GuardianId>
{
    // TODO: Flesh out Guardian entity properties
        // FirstName
        // LastName
        // Relationship to student
        // ContactDetails - new value object
            // Email
            // PhoneNumber - new value object / can have multiple phone numbers
                // CountryCode
                // Number
                // Type
                    // Home / Mobile / Work
            // Address
                // StreetLine1
                // StreetLine2
                // StreetLine3
                // Town / City
                // County
                // PostCode
                // Country
    // TODO: Set up relationship with Student entity
    // TODO: A guardian can have multiple students
    // TODO: A student can have multiple guardians

    private Guardian(GuardianId id)
        : base(id)
    {
    }

    public static Guardian Create()
    {
        return new Guardian(GuardianId.CreateUnique());
    }
}
