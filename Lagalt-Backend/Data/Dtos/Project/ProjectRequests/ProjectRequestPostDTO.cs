namespace Lagalt_Backend.Data.Dtos.ProjectRequests
{
    public class ProjectRequestPostDTO
    {
        public int? ProjectId { get; set; }
        public Guid? UserId { get; set; }
        public DateTime RequestDate { get; set; }
    }
}
