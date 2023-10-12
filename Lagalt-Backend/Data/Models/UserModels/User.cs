using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Lagalt_Backend.Data.Models.MessageModels;
using Lagalt_Backend.Data.Models.OwnerModels;
using Lagalt_Backend.Data.Models.ProjectModels;

namespace Lagalt_Backend.Data.Models.UserModels
{
    [Table(nameof(User))]
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        [StringLength(50)]
        public string UserName { get; set; } = string.Empty;
        [Required]
        [StringLength(50)]
        public string Password { get; set; }
        [StringLength(255)]
        public string Role { get; set; }
        public string? Description { get; set; }
        public string? Education { get; set; }

        //Navigation
        public ICollection<Project> Projects { get; set; }
        public ICollection<Skill> Skills { get; set; }
        public ICollection<PortfolioProject> PortfolioProjects { get; set; }
        public ICollection<Update> Updates { get; set; }
        public ICollection<UserReview> UserReviews { get; set; }
        public ICollection<ProjectRequest> ProjectRequests { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Message> Messages { get; set; }
    }
}
