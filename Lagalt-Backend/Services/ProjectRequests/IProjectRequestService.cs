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
        Task<IEnumerable<ProjectRequest>> GetAllRequestsForUserAsync(Guid userId);
        Task<bool> DeleteRequestAsync(int requestId);
        // Add other methods as needed, like for updating (approving/rejecting) requests
    }
}
