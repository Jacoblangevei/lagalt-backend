using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lagalt_Backend.Data.Models.ProjectModels
{
    [Table(nameof(MilestoneStatus))]
    public class MilestoneStatus
    {
        [Key]
        public int MilestoneStatusId { get; set; }
        [Required]
        public string MilestoneStatusName {  get; set; }

        public ICollection<Milestone> Milestones { get; set; }
    }
}
