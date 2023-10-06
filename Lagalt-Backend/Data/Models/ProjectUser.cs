namespace Lagalt_Backend.Data.Models
{
    public class ProjectUser
    {
        public int ProjectId { get; set;}
        public Project? Projects { get; set; }
        public int UserId { get; set; }
        public User? Users { get; set; }
        
    }
}
