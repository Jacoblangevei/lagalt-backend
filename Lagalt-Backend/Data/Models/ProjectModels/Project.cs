using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Lagalt_Backend.Data.Models.MessageModels;
using Lagalt_Backend.Data.Models.UserModels;
using Newtonsoft.Json;

namespace Lagalt_Backend.Data.Models.ProjectModels
{
    [Table(nameof(Project))]
    public class Project
    {
        [Key]
        public int ProjectId { get; set; }
        [Required]
        [StringLength(150)]
        public string Name { get; set; }
        [Required]
        [StringLength(1000)]
        public string Description { get; set; }
        public string ImageUrl { get; set; }

        [ForeignKey("Owner")]
        public Guid? OwnerId { get; set; }
        public User? Owner { get; set; }

        [ForeignKey("ProjectStatus")]
        public int? ProjectStatusId { get; set; }
        public ProjectStatus? ProjectStatus { get; set; }

        [ForeignKey("ProjectType")]
        public int? ProjectTypeId { get; set; }
        public ProjectType? ProjectType { get; set; }

        public ICollection<User> Users { get; set; }
        public ICollection<Update> Updates { get; set; }
        public ICollection<Milestone> Milestones { get; set; }
        public ICollection<Tag> Tags { get; set; }
        public ICollection<ProjectRequest> ProjectRequests { get; set; }
        public ICollection<Requirement> Requirements { get; set; }
        public ICollection<Message> Messages { get; set; }
        public ICollection<Resource> Resources { get; set; }
    }
}
