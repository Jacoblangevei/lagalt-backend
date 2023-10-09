using Lagalt_Backend.Data.Exceptions;
using Lagalt_Backend.Data.Models.ProjectModels;
using Lagalt_Backend.Data.Models.UserModels;
using Lagalt_Backend.Data.Models.OwnerModels;

namespace Lagalt_Backend.Services.Projects
{
    public interface IProjectService : ICrudService<Project, int>
    {
    }
}
