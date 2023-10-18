using Lagalt_Backend.Data.Exceptions;
using Lagalt_Backend.Data.Models.ProjectModels;

namespace Lagalt_Backend.Services.Projects
{
    public interface IProjectTypeService : ICrudService<ProjectType, int>
    {
        Task<ICollection<ProjectType>> GetAllAsync();
        Task<ProjectType> GetByIdAsync(int id);

        /// <summary>
        /// Gets the projects for a project type. 
        /// If there are no projects, no exception is thrown, an empty set is returned.
        /// </summary>
        /// <param name="id"></param>
        /// <exception cref="EntityNotFoundException"></exception>
        /// <returns></returns>
        Task<ICollection<Project>> GetProjectsAsync(int id);
        Task<ProjectType> AddAsync(ProjectType obj);
        Task DeleteByIdAsync(int id);

    }
}
