using System.ComponentModel.DataAnnotations;

namespace Lagalt_Backend.Data.Dtos.Users
{
    public class UserPostDTO
    {
        [StringLength(50)]
        public string UserName { get; set; } = string.Empty;
        [Required]
        [StringLength(50)]
        public string Password { get; set; }
    }
}
