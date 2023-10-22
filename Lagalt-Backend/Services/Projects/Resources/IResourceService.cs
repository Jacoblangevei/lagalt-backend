using Lagalt_Backend.Data.Models.ProjectModels;

namespace Lagalt_Backend.Services.Projects.Resources
{
    public interface IResourceService : ICrudService<Resource, int>
    {
        Task<List<Resource>> GetAllResourcesInProjectAsync(int id);
        Task<Resource> GetResourceInProjectByIdAsync(int id, int resourceId);
        Task<Resource> AddResourceToProjectAsync(int id, Resource resource);

    }
}
