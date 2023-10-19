namespace Lagalt_Backend.Data.Dtos.Project.Milestones
{
    public class MilestonePostDTO
    {
        public string Title { get; set; }
        public DateTime DueDate { get; set; }
        public string Description { get; set; }
        public string Currency { get; set; }
        public decimal PaymentAmount { get; set; }
    }
}
