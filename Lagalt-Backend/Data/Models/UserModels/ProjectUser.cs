using Lagalt_Backend.Data.Models.ProjectModels;

namespace Lagalt_Backend.Data.Models.UserModels
{
    public class ProjectUser
    {
        public int ProjectId { get; set; }
        public Project? Projects { get; set; }
        public int UserId { get; set; }
        public User? Users { get; set; }

    }
}
