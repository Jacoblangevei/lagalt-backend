namespace Lagalt_Backend.Data.Dtos.Users
{
    public class UserProfileDTO
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Description { get; set; }
        public string Education { get; set; }
        public int[] Projects { get; set; }
        public int[] Skills { get; set; }
        public int[] PortfolioProjects { get; set; }
        public int[] UserReviews { get; set; }

    }
}
