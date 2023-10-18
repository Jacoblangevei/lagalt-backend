using System.ComponentModel.DataAnnotations;

namespace Lagalt_Backend.Data.Dtos.PortfolioProjects
{
    public class PortfolioProjectPostDTO
    {
        [Required]
        [StringLength(100)]
        public string PortfolioProjectName { get; set; }
        [Required]
        [StringLength(100)]
        public string PortfolioProjectDescription { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string ImageUrl { get; set; }
    }
}
