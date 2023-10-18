using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Lagalt_Backend.Data.Models.UserModels;

namespace Lagalt_Backend.Data.Models.ProjectModels
{
    [Table(nameof(Update))]
    public class Update
    {
        [Key]
        public int UpdateId { get; set; }
        [Required]
        [StringLength(255)]
        public string Description { get; set; }
        [Required]
        public DateTime Timestamp { get; set; }

        [ForeignKey("User")]
        public Guid? UserId { get; set; }
        public User? User { get; set; }
        [ForeignKey("ProjectId")]
        public int? ProjectId { get; set; }
        public Project? Project { get; set; }

    }
}
