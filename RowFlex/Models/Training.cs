using System.ComponentModel.DataAnnotations;

namespace RowFlex.Models;

public class Training
{
    [Key] public int Id { get; init; }

    [StringLength(100)] public string? Title { get; set; }

    [Required] public bool Saved { get; set; } = true;

    [Required] 
    public ETreningType TrainingType { get; set; }

}