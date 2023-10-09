using Lagalt_Backend.Data.Models.UserModels;
using Lagalt_Backend.Data.Dtos.Users;

namespace Lagalt_Backend.Services.Users
{
    public interface IUserService : ICrudService<User, int>
    {
        Task<User> GetByIdAsync(int id);

        Task<User> UpdateAsync(User obj);

        Task UpdateProfileAsync(int userId, UserPutDTO userProfileUpdate);
    }
}
