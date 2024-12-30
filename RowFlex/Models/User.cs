using Microsoft.AspNetCore.Identity;

namespace RowFlex.Models;

public class User : IdentityUser
{
    public string? Name { get; set; }

    public string? Surname { get; set; }

    public bool AuthorizedByClub { get; set; } = false;

    public virtual ICollection<ClubCoach> ClubsAsCoach { get; set; }

    public int? ClubId { get; set; }

    public string Role { get; set; }
    public virtual ICollection<WeightMeasurement> WeightMeasurements { get; set; }
    public double? Weight { get; set; }
    public bool IsWeightMeasurementRequired { get; set; } = true;

    public EGender Gender { get; set; }
}

