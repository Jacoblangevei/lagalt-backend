using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lagalt_Backend.Data.Models.ProjectModels
{
    [Table(nameof(ProjectStatus))]
    public class ProjectStatus
    {
        [Key]
        public int StatusId { get; set; }
        [Required]
        public string StatusName { get; set; }

        public ICollection<Project> Projects { get; set;}
    }
}
