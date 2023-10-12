using Lagalt_Backend.Data.Exceptions;
using Lagalt_Backend.Data.Models.ProjectModels;
using Lagalt_Backend.Data;
using Microsoft.EntityFrameworkCore;

namespace Lagalt_Backend.Services.Projects
{
    public class ProjectTypeService : IProjectTypeService
    {
        private readonly LagaltDbContext _context;

        public ProjectTypeService(LagaltDbContext context)
        {
            _context = context;
        }

        public async Task<ICollection<ProjectType>> GetAllAsync()
        {
            return await _context.ProjectTypes.ToListAsync();
        }

        public async Task<ProjectType> GetByIdAsync(int id)
        {
            var prty = await _context.ProjectTypes.Where(pt => pt.ProjectTypeId == id).FirstAsync();

            if (prty is null)
                throw new EntityNotFoundException(nameof(prty), id);

            return prty;
        }

        public async Task<ProjectType> AddAsync(ProjectType obj)
        {
            await _context.ProjectTypes.AddAsync(obj);
            await _context.SaveChangesAsync();
            return obj;
        }

        public async Task DeleteByIdAsync(int id)
        {
            if (!await ProjectTypeExistsAsync(id))
                throw new EntityNotFoundException(nameof(Project), id);

            var proj = await _context.Projects
                .Where(p => p.ProjectId == id)
                .FirstAsync();

            _context.Projects.Remove(proj);
            await _context.SaveChangesAsync();
        }

        //Helping method
        private async Task<bool> ProjectTypeExistsAsync(int id)
        {
            return await _context.ProjectTypes.AnyAsync(pt => pt.ProjectTypeId == id);
        }
    }
}
