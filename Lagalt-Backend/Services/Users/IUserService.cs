using Lagalt_Backend.Data.Models.UserModels;
using Lagalt_Backend.Data.Dtos.Users;

namespace Lagalt_Backend.Services.Users
{
    public interface IUserService : ICrudService<User, int>
    {
        Task<ICollection<User>> GetAllAsync();
        Task<User> GetByIdAsync(int id);

        Task<User> UpdateAsync(User obj);

        Task<User> GetUserProfileAsync(int userId);

        //Add skill
        Task<Skill> AddSkillAsync(Skill obj);
        //Add skill to user
        Task AddSkillToUserAsync(int userId, int skillId);

        //Add portfolio to user

        //Add project request
    }
}
