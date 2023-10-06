using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Lagalt_Backend.Data.Models.ProjectModels
{
    [Table(nameof(Tag))]
    public class Tag
    {
        [Key]
        public int TagId { get; set; }
        [Required]
        public string TagName { get; set; }

        public ICollection<Project> Projects { get; set; }

    }
}
