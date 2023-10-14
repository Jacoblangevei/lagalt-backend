﻿using Microsoft.EntityFrameworkCore;
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

        public async Task<Project> CreateProjectAsync(Project project, Guid ownerId)
        {
            project.OwnerId = ownerId;

            _context.Projects.Add(project);
            await _context.SaveChangesAsync();

            return project;
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
            _context.Entry(obj).Collection(p => p.Tags).IsModified = false; // Ignore tags
            _context.SaveChanges();

            return obj;
        }

        //Tags
        public async Task<Project> AddTagsToProjectAsync(int projectId, int[] tagIds)
        {
            var project = await _context.Projects
                .Include(p => p.Tags)
                .FirstOrDefaultAsync(p => p.ProjectId == projectId);

            if (project == null)
            {
                throw new EntityNotFoundException(nameof(Project), projectId);
            }

            var tagsToAdd = await _context.Tags
                .Where(t => tagIds.Contains(t.TagId))
                .ToListAsync();

            var newTagsList = new List<Tag>(project.Tags);

            newTagsList.AddRange(tagsToAdd);

            project.Tags = newTagsList;

            _context.SaveChanges();

            return project;
        }

        public async Task<Project> RemoveTagFromProjectAsync(int projectId, int tagId)
        {
            var project = await _context.Projects
                .Include(p => p.Tags)
                .FirstOrDefaultAsync(p => p.ProjectId == projectId);

            if (project == null)
            {
                throw new EntityNotFoundException(nameof(Project), projectId);
            }

            var tagToRemove = project.Tags.FirstOrDefault(t => t.TagId == tagId);

            if (tagToRemove != null)
            {
                project.Tags.Remove(tagToRemove);
                _context.SaveChanges();
            }

            return project;
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
