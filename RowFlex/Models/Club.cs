using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace RowFlex.Models;

public class Club
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public virtual ICollection<ClubCoach> Coaches { get; set; }
    public virtual ICollection<ClubMembership> ClubMembers { get; set; }
}
