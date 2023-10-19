using Lagalt_Backend.Data.Models.ProjectModels;

namespace Lagalt_Backend.Services.Projects.ProjectStatuses
{
    public interface IProjectStatusService : ICrudService<ProjectStatus, int>
    {
        Task<List<ProjectStatus>> GetAllProjectStatusesAsync();
        Task<bool> ProjectStatusExistsAsync(int statusId);
    }
}
