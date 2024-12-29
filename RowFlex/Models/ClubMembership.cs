using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace RowFlex.Models;

public class ClubMembership
{
    [Key]
    public int Id { get; set; } // Primary Key

    [Required]
    [ForeignKey(nameof(User))]
    public string AthleteId { get; set; }
    public virtual User Athlete { get; set; }

    [Required]
    [ForeignKey(nameof(Club))]
    public int ClubId { get; set; }
    public virtual Club Club { get; set; }

    public MembershipStatus Status { get; set; } = MembershipStatus.Pending;

    // Dates for tracking membership history
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
}

public enum MembershipStatus
{
    Pending,
    Accepted,
    Rejected
}