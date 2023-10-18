using Lagalt_Backend.Data.Models.MessageModels;
using Lagalt_Backend.Data.Models.ProjectModels;

namespace Lagalt_Backend.Services.Projects.Messages
{
    public interface IMessageProjectService : ICrudService<ProjectRequest, int>
    {
        Task<List<Message>> GetAllMessagesInProjectAsync(int id);
        Task<Message> GetMessageInProjectByIdAsync(int id, int messageId);
        Task<Message> AddMessageToProjectAsync(int id, Message message);
    }
}
