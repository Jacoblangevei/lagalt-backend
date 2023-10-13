using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Lagalt_Backend.Data.Models.UserModels;

namespace Lagalt_Backend.Data.Models.ProjectModels
{
    [Table(nameof(ProjectRequest))]
    public class ProjectRequest
    {
        [Key]
        public int ProjectRequestId { get; set; }
        
        [ForeignKey("ProjectId")]
        public int? ProjectId { get; set; }
        public Project? Project { get; set; }
        
        [ForeignKey("UserId")]
        public Guid? UserId { get; set; }
        public User? User { get; set; }
        public DateTime RequestDate { get; set; }


    }
}
