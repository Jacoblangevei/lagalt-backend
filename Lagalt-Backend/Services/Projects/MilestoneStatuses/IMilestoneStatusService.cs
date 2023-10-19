using Lagalt_Backend.Data.Models.ProjectModels;

namespace Lagalt_Backend.Services.Projects.MilestoneStatuses
{
    public interface IMilestoneStatusService : ICrudService<MilestoneStatus, int>
    {
        Task<List<MilestoneStatus>> GetAllMilestoneStatusesAsync();
        Task<bool> MilestoneStatusExistsAsync(int milestoneStatusId);
    }
}
