using Lagalt_Backend.Data;
using Lagalt_Backend.Data.Models.ProjectModels;
using Microsoft.EntityFrameworkCore;

namespace Lagalt_Backend.Services.Projects.ProjectStatuses
{
    public class ProjectStatusService : IProjectStatusService
    {
        private readonly LagaltDbContext _context;

        public ProjectStatusService(LagaltDbContext context)
        {
            _context = context;
        }
        public async Task<List<ProjectStatus>> GetAllProjectStatusesAsync()
        {
            return await _context.ProjectStatuses.ToListAsync();
        }
    }
}
