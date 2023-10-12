using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lagalt_Backend.Data.Models.ProjectModels
{
    [Table(nameof(Requirement))]
    public class Requirement
    {
        [Key]
        public int RequirementId { get; set; }
        [Required]
        public string RequirementText { get; set;}

        public int ProjectId { get; set; }

        public Project Project { get; set; }
    }
}
