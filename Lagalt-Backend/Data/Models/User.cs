using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lagalt_Backend.Data.Models
{
    [Table(nameof(User))]
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        [StringLength(50)]
        public string UserName { get; set; } = string.Empty;
        [Required]
        [StringLength(50)]
        public string Password { get; set; }
        [StringLength(255)]
        public string Description { get; set; }
        public string Education { get; set; }

        public ICollection<Project> Projects { get; set; }
    }
}
