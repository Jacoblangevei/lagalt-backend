using Lagalt_Backend.Data.Models.ProjectModels;
using Lagalt_Backend.Data;
using Microsoft.EntityFrameworkCore;

namespace Lagalt_Backend.Services.Projects.MilestoneStatuses
{
    public class MilestoneStatusService : IMilestoneStatusService
    {
        private readonly LagaltDbContext _context;

        public MilestoneStatusService(LagaltDbContext context)
        {
            _context = context;
        }
        public async Task<List<MilestoneStatus>> GetAllMilestoneStatusesAsync()
        {
            return await _context.MilestoneStatuses.ToListAsync();
        }
        public async Task<bool> MilestoneStatusExistsAsync(int milestoneStatusId)
        {
            return await _context.MilestoneStatuses.AnyAsync(ms => ms.MilestoneStatusId == milestoneStatusId);
        }
    }
}
