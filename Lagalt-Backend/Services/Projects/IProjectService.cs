using Lagalt_Backend.Data.Models.ProjectModels;
using Lagalt_Backend.Data.Models.MessageModels;

namespace Lagalt_Backend.Services.Projects
{
    public interface IProjectService : ICrudService<Project, int>
    {
        Task<ICollection<Project>> GetAllAsync();

        Task<Project> GetByIdAsync(int id);

        Task<Project> UpdateAsync(Project obj);

        Task<ICollection<Message>> GetMessagesAsync(int id);

        //Add message to project
    }
}
