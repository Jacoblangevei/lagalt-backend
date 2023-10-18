using Microsoft.EntityFrameworkCore;
using Lagalt_Backend.Data;
using System.Data;
using Lagalt_Backend.Data.Models.ProjectModels;
using Lagalt_Backend.Data.Exceptions;
using Lagalt_Backend.Data.Models.UserModels;
using Lagalt_Backend.Services.Projects;

namespace Lagalt_Backend.Services.ProjectRequests
{
    public class ProjectRequestService : IProjectRequestService
    {
        private readonly LagaltDbContext _context;
        private IProjectService _projService;

        public ProjectRequestService(LagaltDbContext context, IProjectService projService)
        {
            _context = context;
            _projService = projService;
        }

        public async Task<IEnumerable<ProjectRequest>> GetAllAsync()
        {
            return await _context.ProjectRequests
                .Include(r => r.Project)
                .Include(r => r.User)
                .ToListAsync();
        }

        public async Task<ProjectRequest> CreateRequestAsync(ProjectRequest request)
        {
            _context.ProjectRequests.Add(request);
            await _context.SaveChangesAsync();
            return request;
        }

        public async Task<ProjectRequest> GetRequestByIdAsync(int requestId)
        {
            return await _context.ProjectRequests
                .Include(r => r.Project)
                .Include(r => r.User)
                .FirstOrDefaultAsync(r => r.ProjectRequestId == requestId);
        }

        public async Task<IEnumerable<ProjectRequest>> GetAllRequestsForProjectAsync(int projectId)
        {
            //Needs to check if user already has requested to join this project

            var requests = await _context.ProjectRequests
                .Where(r => r.ProjectId == projectId)
                .Include(r => r.User)
                .ToListAsync();

            return requests;
        }

        public async Task<bool> DeleteRequestAsync(int requestId)
        {
            var request = await _context.ProjectRequests.FindAsync(requestId);
            if (request == null)
            {
                return false;
            }

            _context.ProjectRequests.Remove(request);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task RemoveProjectFromProjectAsync(int projectId, int requestId)
        {
            var project = await _context.Projects
                .Include(p => p.ProjectRequests)
                .FirstOrDefaultAsync(p => p.ProjectId == projectId);

            if (project == null)
            {
                throw new EntityNotFoundException(nameof(Project), projectId);
            }

            var request = await _context.ProjectRequests.FindAsync(requestId);

            if (request == null)
            {
                throw new EntityNotFoundException(nameof(ProjectRequest), requestId);
            }

            if (project.ProjectRequests.Contains(request))
            {
                project.ProjectRequests.Remove(request);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> AcceptRequestAsync(int projectId, int requestId)
        {
            if (projectId <= 0 || requestId <= 0)
            {
                return false;
            }

            var request = await _context.ProjectRequests.FindAsync(requestId);

            if (request == null)
            {
                return false;
            }

            var userId = request.UserId ?? Guid.Empty;

            var projectUser = new ProjectUser
            {
                ProjectId = projectId,
                UserId = userId,
                Role = "User"
            };

            _context.ProjectUsers.Add(projectUser);
            await _context.SaveChangesAsync();

            _context.ProjectRequests.Remove(request);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> IsUserMemberOfProject(string userId, int projectId)
        {
            Guid userGuid = new Guid(userId);

            var membership = await _context.ProjectUsers
                .FirstOrDefaultAsync(m => m.UserId == userGuid && m.ProjectId == projectId);

            return membership != null;
        }

        public async Task<bool> HasUserSentRequest(string userId, int projectId)
        {
            Guid userGuid = new Guid(userId);

            var existingRequest = await _context.ProjectRequests
                .FirstOrDefaultAsync(r => r.UserId == userGuid && r.ProjectId == projectId);

            return existingRequest != null;
        }
    }
}
