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
    public virtual Club Club { get; set; }


    [Required]
    [ForeignKey(nameof(Training))]
    public string CoachId { get; set; }  // Foreign key to User (Coach)
    public virtual User Coach { get; set; }
}
