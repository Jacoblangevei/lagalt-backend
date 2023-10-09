using System.ComponentModel.DataAnnotations;

namespace Lagalt_Backend.Data.Dtos.Messages
{
    public class MessagePostDTO
    {
        [Required]
        [StringLength(100)]
        public string Subject { get; set; }
        [StringLength(255)]
        public string MessageContent { get; set; }
    }
}
