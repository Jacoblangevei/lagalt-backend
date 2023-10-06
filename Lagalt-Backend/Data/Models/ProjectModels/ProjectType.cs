using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lagalt_Backend.Data.Models.ProjectModels
{
    [Table(nameof(ProjectType))]
    public class ProjectType
    {
        [Key]
        public int ProjectTypeId { get; set; }
        [Required]
        public string ProjectTypeName { get; set; }

        public ICollection<Project> Projects { get; set; }
    }
}
