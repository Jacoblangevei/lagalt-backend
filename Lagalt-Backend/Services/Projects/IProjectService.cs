using Lagalt_Backend.Data.Models.ProjectModels;
using Lagalt_Backend.Data.Models.MessageModels;
using System.ComponentModel.DataAnnotations;

namespace Lagalt_Backend.Services.Projects
{
    public interface IProjectService : ICrudService<Project, int>
    {
        Task<ICollection<Project>> GetAllAsync();

        Task<Project> GetByIdAsync(int id);

        Task<Project> UpdateAsync(Project obj);

        Task<ICollection<Message>> GetMessagesAsync(int id);

        //Get message from project
        Task<Message> GetMessageFromProjectByIdAsync(int id, int messageId);
        
        //Add message to project
        //Task<Message> AddNewMessageToProjectAsync(int id, string messageSubject,string messageContent, string messageImage,  int creatorId, string creatorRole);

    }
}
