using Lagalt_Backend.Data.Models.MessageModels;
using Lagalt_Backend.Data.Models.ProjectModels;
using Lagalt_Backend.Data.Models.UserModels;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Lagalt_Backend.Data.Dtos.Messages
{
    public class MessageDTO
    {
        public int MessageId { get; set; }
        public string Subject { get; set; }
        public string MessageContent { get; set; }
        public string ImageUrl { get; set; }
        public DateTime Timestamp { get; set; }
        public Guid? CreatorId { get; set; }
        public int? ProjectId { get; set; }
        public int[] Comments { get; set; }
    }
}
