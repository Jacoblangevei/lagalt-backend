using System.ComponentModel.DataAnnotations;

namespace Lagalt_Backend.Data.Dtos.Projects
{
    public class ProjectPostDTO
    {
        [Required]
        [StringLength(150)]
        public string Name { get; set; }
        [Required]
        [StringLength(1000)]
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        [Required]
        public int? ProjectTypeId { get; set; }
    }
}
