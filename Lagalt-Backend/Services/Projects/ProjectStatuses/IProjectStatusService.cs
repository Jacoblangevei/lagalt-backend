using Lagalt_Backend.Data.Models.ProjectModels;

namespace Lagalt_Backend.Services.Projects.ProjectStatuses
{
    public interface IProjectStatusService : ICrudService<ProjectRequest, int>
    {
        Task<List<ProjectStatus>> GetAllProjectStatusesAsync();
    }
}
