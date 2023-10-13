using Lagalt_Backend.Data.Models.UserModels;
using Lagalt_Backend.Data.Dtos.Users;
using System.Security.Cryptography;

namespace Lagalt_Backend.Services.Users
{
    public interface IUserService : ICrudService<User, Guid>
    {
        Task<User> UpdateAsync(Guid userId, UserPutDTO userPutDTO);

        Task<User> GetUserProfileAsync(Guid userId);

        //SKills

        Task<ICollection<Skill>> GetUserSkillsAsync(Guid userId);

        Task<Skill> GetSkillByIdAsync(Guid userId, int skillId);

        Task AddNewSkillToUserAsync(Guid userId, string skillName);

        Task RemoveSkillFromUserAsync(Guid userId, int skillId);

        //Portfolios
        Task<ICollection<PortfolioProject>> GetUserPortfolioProjectsAsync(Guid userId);

        Task<PortfolioProject> GetPortfolioProjectByIdAsync(Guid userId, int portfolioProjectId);

        Task AddNewPortfolioProjectToUserAsync(Guid userId, string portfolioProjectName, string portfolioProjectDescription, string imageUrl, DateTime startDate, DateTime endDate);

        Task RemovePortfolioProjectFromUserAsync(Guid userId, int portfolioProjectId);

        //Requests

        //Add project request
    }
}
