using System.ComponentModel.DataAnnotations;

namespace Lagalt_Backend.Data.Dtos.Comments
{
    public class CommentPostDTO
    {
        [Required]
        [StringLength(255)]
        public string CommentText { get; set; }
    }
}
