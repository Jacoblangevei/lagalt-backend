using Lagalt_Backend.Data.Dtos.PortfolioProjects;
using Lagalt_Backend.Data.Dtos.Skills;

namespace Lagalt_Backend.Data.Dtos.Users
{
    public class UserPutDTO
    {
        public string Description { get; set; }
        public string Education { get; set; }
        public List<int> SkillIdsToAdd { get; set; }
        public List<int> SkillIdsToRemove { get; set; }
        public List<int> PortfolioProjectIdsToAdd { get; set; }
        public List<int> PortfolioProjectIdsToRemove { get; set; }
    }
}
