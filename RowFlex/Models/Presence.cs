using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RowFlex.Models;

public class Presence
{
    [Key]
    public int Id { get; init; }

    [Required]
    [ForeignKey(nameof(TrainingPlan))]
    public int TrainingPlanId { get; set; } // Nowe pole dla powiązania z TrainingPlan

    public virtual TrainingPlan? TrainingPlan { get; set; } // Nawigacja do TrainingPlan

    [Required]
    public DateTime Date { get; set; }

    [Required]
    [ForeignKey(nameof(User))]
    public string UserId { get; set; } // Użytkownik, który uczestniczył w treningu

    public virtual User? User { get; set; }

    public bool IsBoatAssigned { get; set; } = false;

    // Opcjonalne dane o treningu:
    public double Watts { get; set; }
    public double WattsPer500m { get; set; }
    public TimeSpan TrainingTime { get; set; }
    public int Cart { get; set; }
    public double Distance { get; set; }
}
