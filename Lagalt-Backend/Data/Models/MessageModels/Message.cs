using Lagalt_Backend.Data.Models.UserModels;
using Lagalt_Backend.Data.Models.OwnerModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Lagalt_Backend.Data.Models.ProjectModels;

namespace Lagalt_Backend.Data.Models.MessageModels
{
    [Table(nameof(Message))]
    public class Message
    {
        [Key]
        public int MessageId { get; set; }
        [Required]
        [StringLength(100)]
        public string Subject { get; set; }
        public string CreatorType { get; set; }
        [StringLength(255)]
        public string MessageContent { get; set; }
        public DateTime Timestamp { get; set; }

        public int? CreatorId { get; set; }
        public User? User { get; set; }
        public Owner? Owner { get; set; }

        [ForeignKey("ProjectId")]
        public int? ProjectId { get; set;}
        public Project? Project { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
