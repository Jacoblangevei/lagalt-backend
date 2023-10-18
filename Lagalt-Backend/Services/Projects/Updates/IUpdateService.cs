using Lagalt_Backend.Data.Models.ProjectModels;

namespace Lagalt_Backend.Services.Projects.Updates
{
    public interface IUpdateService : ICrudService<ProjectType, int>
    {
        Task<List<Update>> GetAllUpdatesInProjectAsync(int id);
        Task<Update> GetUpdateInProjectByIdAsync(int id, int updateId);
        Task<Update> AddUpdateToProjectAsync(int id, Update update);
    }
}
