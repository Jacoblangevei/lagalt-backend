using Lagalt_Backend.Data.Models.UserModels;
using Lagalt_Backend.Data.Dtos.Users;
using System.Security.Cryptography;

namespace Lagalt_Backend.Services.Users
{
    public interface IUserService : ICrudService<User, int>
    {
        Task<User> UpdateAsync(int userId, UserPutDTO userPutDTO);

        Task<User> GetUserProfileAsync(int userId);

        //SKills

        Task<ICollection<Skill>> GetUserSkillsAsync(int userId);

        Task<Skill> GetSkillByIdAsync(int userId, int skillId);

        Task AddNewSkillToUserAsync(int userId, string skillName);

        Task RemoveSkillFromUserAsync(int userId, int skillId);

        //Portfolios
        Task<ICollection<PortfolioProject>> GetUserPortfolioProjectsAsync(int userId);

        Task<PortfolioProject> GetPortfolioProjectByIdAsync(int userId, int portfolioProjectId);

        Task AddNewPortfolioProjectToUserAsync(int userId, string portfolioProjectName, string portfolioProjectDescription, string imageUrl, DateTime startDate, DateTime endDate);

        Task RemovePortfolioProjectFromUserAsync(int userId, int portfolioProjectId);

        //Requests

        //Add project request
    }
}
