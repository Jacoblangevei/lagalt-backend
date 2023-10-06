using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lagalt_Backend.Data.Models
{
    [Table(nameof(Project))]
    public class Project
    {
        [Key]
        public int ProjectId { get; set; }
        [Required]
        [StringLength(150)]
        public string Name { get; set; }
        [Required]
        [StringLength(255)]
        public string Description { get; set; }


        [ForeignKey("Owner")]
        public int? OwnerId { get; set; }
        public Owner? Owner { get; set; }

        public ICollection<User> Users { get; set;}

    }
}
