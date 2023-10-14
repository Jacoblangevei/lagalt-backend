using Lagalt_Backend.Data.Models.UserModels;
using System.ComponentModel.DataAnnotations;

namespace Lagalt_Backend.Data.Dtos.PortfolioProjects
{
    public class PortfolioProjectDTO
    {
        public int PortfolioProjectId { get; set; }
        public string PortfolioProjectName { get; set; }
        public string PortfolioProjectDescription { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string ImageUrl { get; set; }
        public Guid[] Users { get; set; }
    }
}
