using Lagalt_Backend.Data.Models.UserModels;
using Lagalt_Backend.Data.Dtos.Users;

namespace Lagalt_Backend.Services.Users
{
    public interface IUserService : ICrudService<User, int>
    {
        Task<User> GetUserByIdAsync(int id);

        Task<User> UpdateAsync(User obj);

        Task<User> GetUserProfileAsync(int userId);

        Task UpdateProfileAsync(int userId, UserPutDTO userProfileUpdate);
    }
}
