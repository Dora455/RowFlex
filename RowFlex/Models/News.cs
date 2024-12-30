using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RowFlex.Models
{
    public class News
    {
        [Key]
        public int Id { get; init; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required]
        public DateTime PublishedDate { get; set; }
    }
}