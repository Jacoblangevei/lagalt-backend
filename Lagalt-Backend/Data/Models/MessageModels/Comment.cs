using Lagalt_Backend.Data.Models.OwnerModels;
using Lagalt_Backend.Data.Models.UserModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lagalt_Backend.Data.Models.MessageModels
{
    [Table(nameof(Comment))]
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }
        [Required]
        [StringLength(255)]
        public string CommentText { get; set; }
        public string CreatorType { get; set; }
        public DateTime Timestamp { get; set; }

        public int? CreatorId { get; set; }
        public User? User { get; set; }
        public Owner? Owner { get; set; }
        public ICollection<Message> Messages { get; set; }

    }
}
