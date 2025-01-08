using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace RowFlex.Models;

public class TrainingPlan
{
    [Key]
    public int Id { get; init; }

    [Required]
    [ForeignKey(nameof(Training))]
    public int TrainingId { get; set; }

    public virtual Training? Training { get; set; }
    public DateTime TrainingDate { get; set; }

}