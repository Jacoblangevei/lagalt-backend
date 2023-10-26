using Lagalt_Backend.Data.Models.ProjectModels;
using Lagalt_Backend.Data.Models.MessageModels;
using System.ComponentModel.DataAnnotations;
using Lagalt_Backend.Data.Models.UserModels;

namespace Lagalt_Backend.Services.Projects
{
    public interface IProjectService : ICrudService<Project, int>
    {
        Task<ICollection<Project>> GetAllAsync();

        Task<Project> GetByIdAsync(int projectId);
        Task<Project> AddAsync(Project obj);

        Task<Project> CreateProjectAsync(Project project, Guid ownerId);

        Task<Project> UpdateAsync(Project obj);
        Task DeleteByIdAsync(int id);
        Task<ICollection<Project>> GetProjectsUserOwnsAsync(Guid userId);
        Task UpdateStatusInProjectAsync(Project project);

        //Tags
        Task<List<Tag>> GetAllTagsInProjectAsync(int id);
        Task<Tag> GetTagInProjectByIdAsync(int id, int tagId);
        Task<Project> AddTagToProjectAsync(int id, string tagName);
        Task<Project> RemoveTagFromProjectAsync(int id, int tagId);

        //Requirements
        Task<List<Requirement>> GetAllRequirementsInProjectAsync(int id);
        Task<Requirement> GetRequirementInProjectByIdAsync(int id, int requirementId);
        Task<Project> AddRequirementToProjectAsync(int id, string requirementText);
        Task<Project> RemoveRequirementFromProjectAsync(int id, int requirementId);

        //Users
        Task<List<User>> GetAllUsersInProjectAsync(int id);
        Task<Project> RemoveUserFromProjectAsync(int id, Guid userId);
        Task<bool> LeaveProjectAsync(Guid userId, int projectId);

    }
}
