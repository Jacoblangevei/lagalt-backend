using Lagalt_Backend.Data;
using Lagalt_Backend.Data.Exceptions;
using Lagalt_Backend.Data.Models.MessageModels;
using Lagalt_Backend.Data.Models.OwnerModels;
using Lagalt_Backend.Data.Models.ProjectModels;
using Microsoft.EntityFrameworkCore;

namespace Lagalt_Backend.Services.Owners
{
    public class OwnerService : IOwnerService
    {
        private readonly LagaltDbContext _context;

        public OwnerService(LagaltDbContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Owner>> GetAllAsync()
        {
            return await _context.Owners.ToListAsync();
        }

        public async Task<Owner> GetByIdAsync(int id)
        {
            var owr = await _context.Owners.Where(o => o.Id == id).FirstAsync();

            if (owr is null)
                throw new EntityNotFoundException(nameof(owr), id);

            return owr;
        }

        public async Task<Owner> AddAsync(Owner obj)
        {
            await _context.Owners.AddAsync(obj);
            await _context.SaveChangesAsync();
            return obj;
        }

        public async Task DeleteByIdAsync(int id)
        {
            if (!await OwnerExistsAsync(id))
                throw new EntityNotFoundException(nameof(Project), id);

            var owr = await _context.Owners
                .Where(m => m.Id == id)
                .FirstAsync();

            _context.Owners.Remove(owr);
            await _context.SaveChangesAsync();
        }

        //Projects
        public async Task<ICollection<Project>> GetAllProjectsOwnerOwnsAsync(int id)
        {
            if (!await OwnerExistsAsync(id))
                throw new EntityNotFoundException(nameof(Owner), id);

            return await _context.Projects
                .Where(p => p.OwnerId == id)
                .ToListAsync();
        }

        //Helping methods
        private async Task<bool> OwnerExistsAsync(int id)
        {
            return await _context.Owners.AnyAsync(o => o.Id == id);
        }
    }
}
