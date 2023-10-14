﻿﻿using Microsoft.EntityFrameworkCore;
using Lagalt_Backend.Data;
using Lagalt_Backend.Data.Exceptions;
using Lagalt_Backend.Data.Models.ProjectModels;
using Lagalt_Backend.Data.Models.MessageModels;
using System.ComponentModel.Design;

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

            _context.Projects.Remove(proj);
            await _context.SaveChangesAsync();
        }

        public async Task<Project> UpdateAsync(Project obj)
        {
            if (!await ProjectExistsAsync(obj.ProjectId))
                throw new EntityNotFoundException(nameof(Project), obj.ProjectId);

            _context.Entry(obj).State = EntityState.Modified;
            _context.SaveChanges();

            return obj;
        }

        //Messages
        public async Task<ICollection<Message>> GetMessagesAsync(int id)
        {
            if (!await ProjectExistsAsync(id))
                throw new EntityNotFoundException(nameof(Project), id);

            return await _context.Messages
                .Where(m => m.ProjectId == id)
                .ToListAsync();
        }

        public async Task<Message> GetMessageFromProjectByIdAsync(int id, int messageId) 
        {
            var project = await _context.Projects
                .Include(p => p.Messages)
                .FirstOrDefaultAsync(p => p.ProjectId == id);

            if (project == null)
            {
                throw new EntityNotFoundException(nameof(Project), id);
            }

            var message = project.Messages.FirstOrDefault(m => m.MessageId == messageId);

            if (message == null)
            {
                throw new EntityNotFoundException(nameof(Message), messageId);
            }

            return message;
        }

        public async Task<Message> AddNewMessageToProjectAsync(int id, Guid userId, string messageSubject, string messageContent, string messageImage)
        {
            var project = await _context.Projects
                .Include(p => p.Messages)
                .SingleOrDefaultAsync(p => p.ProjectId == id);

            if (project == null)
            {
                return null;
            }

            var message = new Message
            {
                ProjectId = id,
                UserId = userId,
                Subject = messageSubject,
                MessageContent = messageContent,
                ImageUrl = messageImage,
                Timestamp = DateTime.UtcNow
            };

            project.Messages.Add(message);

            await _context.SaveChangesAsync();

            return message;
        }

        //Helping methods
        private async Task<bool> ProjectExistsAsync(int id)
        {
            return await _context.Projects.AnyAsync(p => p.ProjectId == id);
        }
    }
}
