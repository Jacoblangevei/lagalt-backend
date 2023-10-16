namespace Lagalt_Backend.Data.Dtos.ProjectRequests
{
    public class ProjectRequestDTO
    {
        public int ProjectRequestId { get; set; }
        public int? ProjectId { get; set; }
        public string? ProjectName { get; internal set; }
        public Guid? UserId { get; set; }
        public DateTime RequestDate { get; set; }
        public Guid? OwnerId { get; internal set; }

        /* 
        public string ProjectName { get; set; }
        public string UserName { get; set; }
        */
    }
}
