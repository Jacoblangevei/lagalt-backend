using Lagalt_Backend.Data.Exceptions;
using Lagalt_Backend.Data;
using Lagalt_Backend.Data.Models.ProjectModels;
using Microsoft.EntityFrameworkCore;

namespace Lagalt_Backend.Services.Projects.Milestones
{
    public class MilestoneService : IMilestoneService
    {
        private readonly LagaltDbContext _context;

        public MilestoneService(LagaltDbContext context)
        {
            _context = context;
        }

        public async Task<List<Milestone>> GetAllMilestonesInProjectAsync(int id)
        {
            var milestones = await _context.Milestones
            .Where(m => m.ProjectId == id)
            .ToListAsync();

            return milestones;
        }

        public async Task<Milestone> GetMilestoneInProjectByIdAsync(int id, int milestoneId)
        {
            var milestone = await _context.Milestones
                .Where(m => m.ProjectId == id && m.MilestoneId == milestoneId)
                .FirstOrDefaultAsync();

            if (milestone == null)
            {
                throw new EntityNotFoundException(nameof(Milestone), milestoneId);
            }

            return milestone;
        }

        public async Task<Milestone> AddMilestoneToProjectAsync(int id, Milestone milestone)
        {
            milestone.ProjectId = id;
            _context.Milestones.Add(milestone);
            await _context.SaveChangesAsync();
            return milestone;
        }

        public async Task UpdateMilestoneInProjectAsync(Milestone milestone)
        {
            _context.Entry(milestone).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
