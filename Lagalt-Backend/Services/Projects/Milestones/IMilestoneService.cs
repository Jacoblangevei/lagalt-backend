using Lagalt_Backend.Data.Models.ProjectModels;

namespace Lagalt_Backend.Services.Projects.Milestones
{
    public interface IMilestoneService : ICrudService<Milestone, int>
    {
        Task<List<Milestone>> GetAllMilestonesInProjectAsync(int id);
        Task<Milestone> GetMilestoneInProjectByIdAsync(int id, int milestoneId);
        Task<Milestone> AddMilestoneToProjectAsync(int id, Milestone milestone);
        Task UpdateMilestoneInProjectAsync(Milestone milestone);
    }
}
