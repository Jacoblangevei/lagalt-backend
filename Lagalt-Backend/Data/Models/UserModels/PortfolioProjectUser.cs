namespace Lagalt_Backend.Data.Models.UserModels
{
    public class PortfolioProjectUser
    {
        public int PortfolioProjectId { get; set; }
        public PortfolioProject? PortfolioProjects { get; set; }
        public int UserId { get; set; }
        public User? Users { get; set; }
    }
}
