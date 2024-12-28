using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace RowFlex.Models;

public class ClubCoach
{
    [Key]
    public int Id { get; set; }

    [Required]
    [ForeignKey(nameof(Training))]
    public int ClubId { get; set; }

    [Required]
    [ForeignKey(nameof(Training))]
    public int CoachId { get; set; }  // Foreign key to User (Coach)
}
