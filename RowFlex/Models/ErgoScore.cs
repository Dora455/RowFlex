using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RowFlex.Models;

public class ErgoScore
{
    [Key]
    public int Id { get; init; }

    [Required]
    [ForeignKey(nameof(Training))]
    public int TrainingId { get; set; } 

    [Required]
    [ForeignKey(nameof(User))]
    public int UserId { get; set; } 

    public double Watts {get; set;}
    public double WattsPer500m { get; set; } 
    public TimeSpan TrainingTime { get; set; } 
    public int Cart { get; set; } 
    public double Distance { get; set; } 

    public User? User { get; set; }  
    public Training? Training { get; set; }
}

