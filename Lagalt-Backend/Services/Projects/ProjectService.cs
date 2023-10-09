﻿using Microsoft.EntityFrameworkCore;
using Lagalt_Backend.Data;
using Lagalt_Backend.Data.Exceptions;
using Lagalt_Backend.Data.Models.ProjectModels;

namespace Lagalt_Backend.Services.Projects
{
    public class ProjectService : IProjectService
    {

        private readonly LagaltDbContext _context;

        public ProjectService(LagaltDbContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Project>> GetAllAsync()
        {
            return await _context.Projects.Include(p => p.Tags).ToListAsync();
        }

        public async Task<Project> GetByIdAsync(int id)
        {
            var proj = await _context.Projects.Where(p => p.ProjectId == id).FirstAsync();

            if (proj is null)
                throw new EntityNotFoundException(nameof(proj), id);

            return proj;
        }

        public async Task<Project> AddAsync(Project obj)
        {
            await _context.Projects.AddAsync(obj);
            await _context.SaveChangesAsync();
            return obj;
        }

        public async Task DeleteByIdAsync(int id)
        {
            if (!await ProjectExistsAsync(id))
                throw new EntityNotFoundException(nameof(Project), id);

            var proj = await _context.Projects
                .Where(p => p.ProjectId == id)
                .FirstAsync();

            proj.Users.Clear(); //MIght not be needed

            _context.Projects.Remove(proj);
            await _context.SaveChangesAsync();
        }

        public async Task<Project> UpdateAsync(Project obj)
        {
            if (!await ProjectExistsAsync(obj.ProjectId))
                throw new EntityNotFoundException(nameof(Project), obj.ProjectId);

            obj.Users.Clear();

            _context.Entry(obj).State = EntityState.Modified;
            _context.SaveChanges();

            return obj;
        }

        //Helping methods
        private async Task<bool> ProjectExistsAsync(int id)
        {
            return await _context.Projects.AnyAsync(p => p.ProjectId == id);
        }
    }
}
