using Lagalt_Backend.Data.Models.MessageModels;
using Lagalt_Backend.Data.Models.OwnerModels;
using Lagalt_Backend.Data.Models.ProjectModels;
using Lagalt_Backend.Data.Models.UserModels;
using System.ComponentModel.DataAnnotations;

namespace Lagalt_Backend.Data.Dtos.Users
{
    public class UserDTO
    {
        public int UserId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; }
        public string Description { get; set; }
        public string Education { get; set; }

        public int[] Projects { get; set; }
        public int[] Skills { get; set; }
        public int[] PortfolioProjects { get; set; }
        public int[] Updates { get; set; }
        public int[] UserReviews { get; set; }
        public int[] ProjectRequests { get; set; }
        public int[] Comments { get; set; }
        public int[] Messages { get; set; }
    }
}
