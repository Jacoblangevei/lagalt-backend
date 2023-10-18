using Lagalt_Backend.Data;
using Lagalt_Backend.Data.Exceptions;
using Lagalt_Backend.Data.Models.ProjectModels;
using Microsoft.EntityFrameworkCore;

namespace Lagalt_Backend.Services.Projects.Updates
{
    public class UpdateService : IUpdateService
    {
        private readonly LagaltDbContext _context;

        public UpdateService(LagaltDbContext context)
        {
            _context = context;
        }

        public async Task<List<Update>> GetAllUpdatesInProjectAsync(int id)
        {
            var updates = await _context.Updates
            .Where(u => u.ProjectId == id)
            .ToListAsync();

            return updates;
        }

        public async Task<Update> GetUpdateInProjectByIdAsync(int id, int updateId)
        {
            var update = await _context.Updates
               .Where(u => u.ProjectId == id)
               .SingleOrDefaultAsync();

            if (update == null)
            {
                throw new EntityNotFoundException(nameof(Update), updateId);
            }

            return update;
        }

        public async Task<Update> AddUpdateToProjectAsync(int id, Update update)
        {
            update.ProjectId = id;
            _context.Updates.Add(update);
            await _context.SaveChangesAsync();
            return update;
        }
    }
}
