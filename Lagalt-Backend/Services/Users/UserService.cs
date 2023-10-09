using Lagalt_Backend.Data;
using Lagalt_Backend.Data.Exceptions;
using Lagalt_Backend.Data.Models.ProjectModels;
using Lagalt_Backend.Data.Models.UserModels;
using Lagalt_Backend.Data.Dtos.Users;
using Microsoft.EntityFrameworkCore;

namespace Lagalt_Backend.Services.Users
{
    public class UserService : IUserService
    {

        private readonly LagaltDbContext _context;

        public UserService(LagaltDbContext context)
        {
            _context = context;
        }

        public async Task<User> AddAsync(User obj)
        {
            await _context.Users.AddAsync(obj);
            await _context.SaveChangesAsync();
            return obj;
        }

        public async Task DeleteByIdAsync(int id)
        {
            if (!await UserExistsAsync(id))
                throw new EntityNotFoundException(nameof(User), id);
            var user = await _context.Users
            .Where(u => u.UserId == id)
                .FirstAsync();

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }
        public async Task<User> GetByIdAsync(int id)
        {
            var user = await _context.Users.Where(u => u.UserId == id).FirstAsync();

            if (user is null)
                throw new EntityNotFoundException(nameof(user), id);

            return user;
        }

        public async Task<User> UpdateAsync(User obj)
        {
            if (!await UserExistsAsync(obj.UserId))
                throw new EntityNotFoundException(nameof(User), obj.UserId);

            _context.Entry(obj).State = EntityState.Modified;
            _context.SaveChanges();

            return obj;
        }

        public async Task UpdateProfileAsync(int id, UserPutDTO obj)
        {
            var user = await _context.Users.Where(u => u.UserId == id).FirstAsync();
            if (user is null)
                throw new EntityNotFoundException(nameof(user), id);

            //TBA

        }

        //Helping methods
        private async Task<bool> UserExistsAsync(int id)
        {
            return await _context.Users.AnyAsync(u => u.UserId == id);
        }
    }
}
