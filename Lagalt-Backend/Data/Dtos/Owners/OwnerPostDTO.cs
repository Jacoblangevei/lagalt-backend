using System.ComponentModel.DataAnnotations;

namespace Lagalt_Backend.Data.Dtos.Owners
{
    public class OwnerPostDTO
    {
        [StringLength(50)]
        public string Username { get; set; }
        [StringLength(50)]
        public string Password { get; set; }
    }
}
