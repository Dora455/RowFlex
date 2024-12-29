using Microsoft.AspNetCore.Identity;

namespace RowFlex.Models;

// Add profile data for application users by adding properties to the User class
public class User : IdentityUser
{
    public string? Name { get; set; }

    public string? Surname { get; set; }

    public bool AuthorizedByClub { get; set; } = false;

    // Navigation property to clubs the coach belongs to
    public virtual ICollection<ClubCoach> ClubsAsCoach { get; set; }

    // Navigation property for the club the athlete belongs to (only for athletes)
    public int? ClubId { get; set; }

    public double? Weight { get; set; }
    public string Role { get; set; }
}

