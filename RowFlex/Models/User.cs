using Microsoft.AspNetCore.Identity;

namespace RowFlex.Models;

// Add profile data for application users by adding properties to the User class
public class User : IdentityUser
{
    public string? Name { get; set; }

    public string? Surname { get; set; }

    public ERole Role { get; init; }
}

