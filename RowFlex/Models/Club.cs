using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace RowFlex.Models;

public class Club
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }

    // Many-to-many relationship between Club and Coach
    public virtual ICollection<ClubCoach> Coaches { get; set; }  // Coaches associated with the club

    // Navigation property for athletes
    public virtual ICollection<ClubMembership> ClubMembers { get; set; }
}
