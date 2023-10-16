using Lagalt_Backend.Data.Models.ProjectModels;
using Lagalt_Backend.Data.Models.MessageModels;
using System.ComponentModel.DataAnnotations;

namespace Lagalt_Backend.Services.Projects
{
    public interface IProjectService : ICrudService<Project, int>
    {
        Task<ICollection<Project>> GetAllAsync();

        Task<Project> GetByIdAsync(int id);

        Task<Project> CreateProjectAsync(Project project, Guid ownerId);

        Task<Project> UpdateAsync(Project obj);

        Task<ICollection<Message>> GetMessagesAsync(int id);

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

        //Messages
        Task<Message> GetMessageFromProjectByIdAsync(int id, int messageId);
        
        Task<Message> AddNewMessageToProjectAsync(int id, Guid userId, string messageSubject,string messageContent, string messageImage);

    }
}
