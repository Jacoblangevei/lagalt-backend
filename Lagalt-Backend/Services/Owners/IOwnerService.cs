using Lagalt_Backend.Data.Models.ProjectModels;
using Lagalt_Backend.Data.Models.OwnerModels;

namespace Lagalt_Backend.Services.Owners
{
    public interface IOwnerService : ICrudService<Owner, int>
    {
        //Get all projects owner owns
        Task<ICollection<Project>> GetAllProjectsOwnerOwnsAsync(int id);
        Task<Project> GetOwnerProjectAsync(int id, int projectId);
        Task<Project> CreateProjectAsync(int id, Project projectModel);

        //Add user to project from request

        //Decline/delete user from request project

        //edit project
        //-change status
        //-type
        //-add/remove tags
        //Update description
        //Update name
    }
}
