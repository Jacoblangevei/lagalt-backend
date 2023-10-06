using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Lagalt_Backend.Data.Models.UserModels
{
    [Table(nameof(PortfolioProject))]
    public class PortfolioProject
    {
        [Key]
        public int PortfolioProjectId { get; set; }
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

        //Navigation
        public ICollection<User> Users { get; set; }
    }
}
