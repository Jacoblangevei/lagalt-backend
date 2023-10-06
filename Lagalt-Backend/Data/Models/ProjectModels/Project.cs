using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Lagalt_Backend.Data.Models.OwnerModels;
using Lagalt_Backend.Data.Models.UserModels;

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
        [StringLength(255)]
        public string Description { get; set; }


        [ForeignKey("Owner")]
        public int? OwnerId { get; set; }
        public Owner? Owner { get; set; }

        public ICollection<User> Users { get; set; }
        public ICollection<Update> Updates { get; set; }
        public ICollection<Milestone> Milestones { get; set; }
        public ICollection<Tag> Tags { get; set; }

    }
}
