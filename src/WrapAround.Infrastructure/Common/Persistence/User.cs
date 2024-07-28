using Microsoft.AspNetCore.Identity;

namespace WrapAround.Infrastructure.Common.Persistence;

// Should we also have a User domain model?
// Feels like there shouldn't be a dependency on IdentityUser for the Domain layer?
    // No there shouldn't. We should have a domain User to map between.
public class User : IdentityUser
{

}
