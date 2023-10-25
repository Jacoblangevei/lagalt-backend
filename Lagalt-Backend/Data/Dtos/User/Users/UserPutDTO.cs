using Lagalt_Backend.Data.Dtos.PortfolioProjects;
using Lagalt_Backend.Data.Dtos.Skills;
using System.ComponentModel.DataAnnotations;

namespace Lagalt_Backend.Data.Dtos.Users
{
    public class UserPutDTO
    {
        [StringLength(1000)]
        public string Description { get; set; }
        public string Education { get; set; }
    }
}
