﻿using Microsoft.EntityFrameworkCore;
using Lagalt_Backend.Data;
using Lagalt_Backend.Data.Exceptions;
using Lagalt_Backend.Data.Models.ProjectModels;
using Lagalt_Backend.Data.Models.MessageModels;
using System.ComponentModel.Design;
using Lagalt_Backend.Data.Models.UserModels;
using Lagalt_Backend.Data.Dtos.Projects;

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

        public async Task<Project> GetByIdAsync(int projectId)
        {
            var proj = await _context.Projects.Where(p => p.ProjectId == projectId).FirstAsync();

            if (proj is null)
                throw new EntityNotFoundException(nameof(proj), projectId);

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

            var projectUser = new ProjectUser
            {
                ProjectId = project.ProjectId,
                UserId = ownerId,
                Role = "Owner"
            };

            _context.ProjectUsers.Add(projectUser);
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

        public async Task<ICollection<Project>> GetProjectsUserOwnsAsync(Guid userId)
        {
            var projects = await _context.ProjectUsers
            .Where(pu => pu.UserId == userId && pu.Role == "Owner")
            .Select(pu => pu.Projects)
            .ToListAsync();

            return projects;
        }

        //Tags
        public async Task<List<Tag>> GetAllTagsInProjectAsync(int id)
        {
            var project = await _context.Projects.FindAsync(id);

            if (project == null)
            {
                throw new EntityNotFoundException(nameof(Project), id);
            }

            var tagIds = await _context.ProjectTags
                .Where(pt => pt.ProjectId == id)
                .Select(pt => pt.TagId)
                .ToListAsync();

            var tags = await _context.Tags
                .Where(t => tagIds.Contains(t.TagId))
                .ToListAsync();

            return tags;
        }

        public async Task<Tag> GetTagInProjectByIdAsync(int id, int tagId)
        {
            var project = await _context.Projects.FindAsync(id);

            if (project == null)
            {
                throw new EntityNotFoundException(nameof(Project), id);
            }

            var tag = await _context.ProjectTags
                .Where(pt => pt.ProjectId == id && pt.TagId == tagId)
                .Select(pt => pt.Tags)
                .FirstOrDefaultAsync();

            if (tag == null)
            {
                throw new EntityNotFoundException(nameof(Tag), tagId);
            }

            return tag;
        }

        public async Task<Project> AddTagToProjectAsync(int id, string tagName)
        {
            var project = await _context.Projects
                .Include(p => p.Tags)
                .FirstOrDefaultAsync(p => p.ProjectId == id);

            if (project == null)
            {
                throw new EntityNotFoundException(nameof(Project), id);
            }

            // Check if the tag already exists in the database
            var existingTag = await _context.Tags
                .FirstOrDefaultAsync(t => t.TagName == tagName);

            if (existingTag == null)
            {
                // Create a new tag if it doesn't exist
                var newTag = new Tag { TagName = tagName };
                _context.Tags.Add(newTag);
                await _context.SaveChangesAsync(); // Save changes to generate the new tag's ID
                existingTag = newTag;
            }

            // Check if the tag is already associated with the project
            if (!project.Tags.Any(t => t.TagId == existingTag.TagId))
            {
                project.Tags.Add(existingTag);
                var projectTag = new ProjectTag { ProjectId = id, TagId = existingTag.TagId };
                _context.ProjectTags.Add(projectTag);
                await _context.SaveChangesAsync();
            }
            return project;
        }

        public async Task<Project> RemoveTagFromProjectAsync(int id, int tagId)
        {
            var project = await _context.Projects
                .Include(p => p.Tags)
                .FirstOrDefaultAsync(p => p.ProjectId == id);

            if (project == null)
            {
                throw new EntityNotFoundException(nameof(Project), id);
            }

            var tagToRemove = project.Tags.FirstOrDefault(t => t.TagId == tagId);

            if (tagToRemove != null)
            {
                project.Tags.Remove(tagToRemove);
                _context.SaveChanges();
            }

            return project;
        }

        //Requirements
        public async Task<List<Requirement>> GetAllRequirementsInProjectAsync(int id)
        {
            var project = await _context.Projects.FindAsync(id);

            if (project == null)
            {
                throw new EntityNotFoundException(nameof(Project), id);
            }

            var requirementIds = await _context.ProjectRequirements
                .Where(pr => pr.ProjectId == id)
                .Select(pr => pr.RequirementId)
                .ToListAsync();

            var requirements = await _context.Requirements
                .Where(r => requirementIds.Contains(r.RequirementId))
                .ToListAsync();

            return requirements;
        }

        public async Task<Requirement> GetRequirementInProjectByIdAsync(int id, int requirementId)
        {
            var project = await _context.Projects.FindAsync(id);

            if (project == null)
            {
                throw new EntityNotFoundException(nameof(Project), id);
            }

            var requirement = await _context.ProjectRequirements
                .Where(pr => pr.ProjectId == id && pr.RequirementId == requirementId)
                .Select(pt => pt.Requirements)
                .FirstOrDefaultAsync();

            if (requirement == null)
            {
                throw new EntityNotFoundException(nameof(Requirement), requirementId);
            }

            return requirement;
        }

        public async Task<Project> AddRequirementToProjectAsync(int id, string requirementText)
        {
            var project = await _context.Projects
                .Include(p => p.Requirements)
                .FirstOrDefaultAsync(p => p.ProjectId == id);

            if (project == null)
            {
                throw new EntityNotFoundException(nameof(Project), id);
            }

            // Check if the requirement already exists in the database
            var existingRequirement = await _context.Requirements
                .FirstOrDefaultAsync(r => r.RequirementText == requirementText);

            if (existingRequirement == null)
            {
                // Create a new if it doesn't exist
                var newRequirement = new Requirement { RequirementText = requirementText };
                _context.Requirements.Add(newRequirement);
                await _context.SaveChangesAsync(); // Save changes to generate the new ID
                existingRequirement = newRequirement;
            }

            // Check if it is already associated with the project
            if (!project.Requirements.Any(r => r.RequirementId == existingRequirement.RequirementId))
            {
                project.Requirements.Add(existingRequirement);
                var projectRequirement = new ProjectRequirement { ProjectId = id, RequirementId = existingRequirement.RequirementId };
                _context.ProjectRequirements.Add(projectRequirement);
                await _context.SaveChangesAsync();
            }
            return project;
        }

        public async Task<Project> RemoveRequirementFromProjectAsync(int id, int requirementId)
        {
            var project = await _context.Projects
                .Include(p => p.Requirements)
                .FirstOrDefaultAsync(p => p.ProjectId == id);

            if (project == null)
            {
                throw new EntityNotFoundException(nameof(Project), id);
            }

            var requirementToRemove = project.Requirements.FirstOrDefault(r => r.RequirementId == requirementId);

            if (requirementToRemove != null)
            {
                project.Requirements.Remove(requirementToRemove);
                _context.SaveChanges();
            }

            return project;
        }

        //Helping methods
        private async Task<bool> ProjectExistsAsync(int id)
        {
            return await _context.Projects.AnyAsync(p => p.ProjectId == id);
        }
    }
}
