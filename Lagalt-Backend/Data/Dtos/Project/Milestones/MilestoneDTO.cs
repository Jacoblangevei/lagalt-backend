using Lagalt_Backend.Data.Models.ProjectModels;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Lagalt_Backend.Data.Dtos.Project.Milestones
{
    public class MilestoneDTO
    {
        public int MilestoneId { get; set; }
        public string Title { get; set; }
        public DateTime DueDate { get; set; }
        public string Description { get; set; }
        public string Currency { get; set; }
        public decimal PaymentAmount { get; set; }
        public int? ProjectId { get; set; }
        public int? MilestoneStatusId { get; set; }
    }
}
