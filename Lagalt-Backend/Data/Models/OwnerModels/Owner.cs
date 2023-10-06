using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Lagalt_Backend.Data.Models.ProjectModels;

namespace Lagalt_Backend.Data.Models.OwnerModels
{
    [Table(nameof(Owner))]
    public class Owner
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string Username { get; set; }
        [StringLength(50)]
        public string Password { get; set; }

        public ICollection<Project> Projects { get; set; }
    }
}
