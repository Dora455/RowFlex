using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RowFlex.Models
{
    public class WeightMeasurement
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey(nameof(User))]
        public string AthleteId { get; set; }
        public virtual User Athlete { get; set; }

        [Required]
        public double Weight { get; set; }
        public DateTime Date { get; set; }
    }
}
