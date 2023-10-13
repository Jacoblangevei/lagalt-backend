using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Lagalt_Backend.Data.Models.UserModels;
using Microsoft.EntityFrameworkCore;

namespace Lagalt_Backend.Data.Models.ProjectModels
{
    [Table(nameof(Milestone))]  
    public class Milestone
    {
        [Key]
        public int MilestoneId { get; set; }
        public string Title { get; set; }
        public DateTime DueDate { get; set; }
        [StringLength(255)]
        public string Description { get; set; }
        public string Currency { get; set; }
        public decimal PaymentAmount { get; set; }

        [ForeignKey("Project")]
        public int? ProjectId { get; set; }
        public Project? Project { get; set; }

        [ForeignKey("Status")]
        public int? MilestoneStatusId { get; set; }
        public MilestoneStatus? MilestoneStatus { get; set; }

    }
}
