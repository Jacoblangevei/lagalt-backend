using Lagalt_Backend.Data;
using Lagalt_Backend.Data.Exceptions;
using Lagalt_Backend.Data.Models.ProjectModels;
using Microsoft.EntityFrameworkCore;

namespace Lagalt_Backend.Services.Projects.Resources
{
    public class ResourceService : IResourceService
    {
        private readonly LagaltDbContext _context;

        public ResourceService(LagaltDbContext context)
        {
            _context = context;
        }
        public async Task<List<Resource>> GetAllResourcesInProjectAsync(int id)
        {
            var resources = await _context.Resources
            .Where(r => r.ProjectId == id)
            .ToListAsync();

            return resources;
        }

        public async Task<Resource> GetResourceInProjectByIdAsync(int id, int resourceId)
        {
            var resource = await _context.Resources
               .Where(r => r.ProjectId == id)
               .SingleOrDefaultAsync();

            if (resource == null)
            {
                throw new EntityNotFoundException(nameof(Resources), resourceId);
            }

            return resource;
        }

        public async Task<Resource> AddResourceToProjectAsync(int id, Resource resource)
        {
            resource.ProjectId = id;
            _context.Resources.Add(resource);
            await _context.SaveChangesAsync();
            return resource;
        }
    }
}
