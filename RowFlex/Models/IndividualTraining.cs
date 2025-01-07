using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace RowFlex.Models;

public class IndividualTraining
{
    [Key]
    public int Id { get; init; }

    [Required]
    [ForeignKey(nameof(Training))]
    public int TrainingId { get; set; }

    public Training? Training { get; set; }

    [Required]
    [ForeignKey(nameof(User))]
    public string UserId { get; set; }

    public User? User { get; set; }

    public DateTime TrainingDate { get; set; }

    //progress 
    public double Watts { get; set; }
    
    public double WattsPer500m { get; set; } 
    
    public TimeSpan TrainingTime { get; set; } 
    
    public int Cart { get; set; } 
    
    public double Distance { get; set; }    
}
