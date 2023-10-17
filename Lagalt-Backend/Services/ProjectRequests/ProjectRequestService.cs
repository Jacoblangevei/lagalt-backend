using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Lagalt_Backend.Data;
using System.Data;
using Lagalt_Backend.Data.Models.ProjectModels;
using Lagalt_Backend.Data.Dtos.ProjectRequests;
using Lagalt_Backend.Data.Exceptions;
using Lagalt_Backend.Data.Models.UserModels;

namespace Lagalt_Backend.Services.ProjectRequests
{
    public class ProjectRequestService : IProjectRequestService
    {
        private readonly LagaltDbContext _context;

        public ProjectRequestService(LagaltDbContext context)
        {
            _context = context;
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

        public async Task<IEnumerable<ProjectRequest>> GetAllRequestsForUserAsync(Guid userId)
        {
            return await _context.ProjectRequests
                .Where(r => r.UserId == userId)
                .Include(r => r.Project)
                .ToListAsync();
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

        Task<ICollection<ProjectRequest>> ICrudService<ProjectRequest, int>.GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ProjectRequest> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ProjectRequest> AddAsync(ProjectRequest obj)
        {
            throw new NotImplementedException();
        }

        public Task DeleteByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        // Implement other methods as needed, like for updating (approving/rejecting) requests
    }
}
