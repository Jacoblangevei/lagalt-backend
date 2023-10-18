using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Lagalt_Backend.Data.Models.ProjectModels;

namespace Lagalt_Backend.Services.ProjectRequests
{
    public interface IProjectRequestService : ICrudService<ProjectRequest, int>
    {
        Task<ProjectRequest> CreateRequestAsync(ProjectRequest request);
        Task<ProjectRequest> GetRequestByIdAsync(int requestId);
        Task<IEnumerable<ProjectRequest>> GetAllRequestsForProjectAsync(int projectId);
        Task<bool> DeleteRequestAsync(int requestId);
        Task RemoveProjectFromProjectAsync(int projectId, int requestId);
        Task<bool> AcceptRequestAsync(int projectId, int requestId);
        Task<bool> IsUserMemberOfProject(string userId, int projectId);
        Task<bool> HasUserSentRequest(string userId, int projectId);
    }
}
