using System.ComponentModel.DataAnnotations;

namespace Lagalt_Backend.Data.Dtos.Projects
{
    public class ProjectPutDTO
    {
        public int ProjectId { get; set; }
        [Required]
        [StringLength(150)]
        public string Name { get; set; }
        [Required]
        [StringLength(255)]
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}
