using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace Lagalt_Backend.Data.Dtos.Users
{
    public class UserPostDTO
    {
        [Required]
        [StringLength(50)]
        public string UserName { get; set; }
        [Required]
        [StringLength(50)]
        public string Password {  get; set; }
    }
}
