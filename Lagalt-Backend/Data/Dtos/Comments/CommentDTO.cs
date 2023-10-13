using Lagalt_Backend.Data.Models.MessageModels;
using Lagalt_Backend.Data.Models.OwnerModels;
using Lagalt_Backend.Data.Models.UserModels;
using System.ComponentModel.DataAnnotations;

namespace Lagalt_Backend.Data.Dtos.Comments
{
    public class CommentDTO
    {
        public int CommentId { get; set; }
        public string CommentText { get; set; }
        public string CreatorType { get; set; }
        public DateTime Timestamp { get; set; }
        public int CreatorId { get; set; }
        public User User { get; set; }
        public Owner Owner { get; set; }
        public int MessageId { get; set; }
    }
}
