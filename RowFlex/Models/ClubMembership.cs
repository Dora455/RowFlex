using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace RowFlex.Models;

public class ClubMembership
{
    [Key]
    public int Id { get; set; } // Primary Key

    [Required]
    [ForeignKey(nameof(Training))]
    public string AthleteId { get; set; }

    [Required]
    [ForeignKey(nameof(Training))]
    public int ClubId { get; set; }

    public MembershipStatus Status { get; set; }

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