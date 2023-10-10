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

        public async Task<ICollection<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserId == id);

            if (user is null)
                throw new EntityNotFoundException(nameof(User), id);

            return user;
        }

        public async Task<User> AddAsync(User obj)
        {
            _context.Users.Add(obj);
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

        public async Task<User> UpdateAsync(User obj)
        {
            if (!await UserExistsAsync(obj.UserId))
                throw new EntityNotFoundException(nameof(User), obj.UserId);

            _context.Entry(obj).State = EntityState.Modified;
            _context.SaveChanges();

            return obj;
        }

        public async Task<User> GetUserProfileAsync(int userId)
        {
            var user = await _context.Users
                .Include(u => u.Skills)
                .Include(u => u.PortfolioProjects)
                .FirstOrDefaultAsync(u => u.UserId == userId);
            
            if (user == null)
            {
                throw new EntityNotFoundException(nameof(User), userId);
            }

            return user;
        }

        public async Task<Skill> AddSkillAsync (Skill obj)
        {
            await _context.Skills.AddAsync(obj);
            await _context.SaveChangesAsync();
            return obj;
        }

        public async Task AddSkillToUserAsync(int userId, int skillId)
        {
            var skill = await _context.Skills.FindAsync(skillId) ?? throw new EntityNotFoundException(nameof(Skill), skillId);
            var user = await _context.Users.FindAsync(userId) ?? throw new EntityNotFoundException(nameof(User), userId);

            user.Skills.Add(skill);
            await _context.SaveChangesAsync();;
        }

        //Helping methods
        private async Task<bool> UserExistsAsync(int id)
        {
            return await _context.Users.AnyAsync(u => u.UserId == id);
        }
    }
}
