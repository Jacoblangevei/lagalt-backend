﻿using Lagalt_Backend.Data;
using Lagalt_Backend.Data.Exceptions;
using Lagalt_Backend.Data.Models.UserModels;
using Lagalt_Backend.Data.Dtos.Users;
using Microsoft.EntityFrameworkCore;
using Lagalt_Backend.Data.Dtos.PortfolioProjects;
using Lagalt_Backend.Data.Models.ProjectModels;
using System.Data;

namespace Lagalt_Backend.Services.Users
{
    public class UserService : IUserService
    {

        private readonly LagaltDbContext _context;

        public UserService(LagaltDbContext context)
        {
            _context = context;
        }

        public async Task<ICollection<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetByIdAsync(Guid id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserId == id);

            if (user is null)
                throw new UserNotFoundException(nameof(User), id);

            return user;
        }

        public async Task<User> AddAsync(User obj)
        {
            _context.Users.Add(obj);
            await _context.SaveChangesAsync();
            return obj;
        }

        public async Task DeleteByIdAsync(Guid id)
        {
            if (!await UserExistsAsync(id))
                throw new UserNotFoundException(nameof(User), id);
            var user = await _context.Users
            .Where(u => u.UserId == id)
                .FirstAsync();

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }

        public async Task<User> UpdateAsync(Guid userId, UserPutDTO userPutDTO)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserId == userId);

            if (user == null)
            {
                throw new UserNotFoundException(nameof(User), userId);
            }

            if (!string.IsNullOrEmpty(userPutDTO.Description))
            {
                user.Description = userPutDTO.Description;
            }

            if (!string.IsNullOrEmpty(userPutDTO.Education))
            {
                user.Education = userPutDTO.Education;
            }

            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User> GetUserProfileAsync(Guid userId)
        {
            var user = await _context.Users
                .Include(u => u.Skills)
                .Include(u => u.PortfolioProjects)
                .FirstOrDefaultAsync(u => u.UserId == userId);
            
            if (user == null)
            {
                throw new UserNotFoundException(nameof(User), userId);
            }

            return user;
        }

        //SKILLS
        public async Task<ICollection<Skill>> GetUserSkillsAsync(Guid userId)
        {
            var user = await _context.Users
                .Include(u => u.Skills)
                .FirstOrDefaultAsync(u => u.UserId == userId);

            if (user is null)
                throw new UserNotFoundException(nameof(User), userId);

            return user.Skills;
        }

        public async Task<Skill> GetSkillByIdAsync(Guid userId, int skillId)
        {
            var user = await _context.Users
                .Include(u => u.Skills)
                .FirstOrDefaultAsync(u => u.UserId == userId);

            if (user == null)
            {
                throw new UserNotFoundException(nameof(User), userId);
            }

            var skill = user.Skills.FirstOrDefault(s => s.SkillId == skillId);

            if (skill == null)
            {
                throw new EntityNotFoundException(nameof(Skill), skillId);
            }

            return skill;
        }

        public async Task AddNewSkillToUserAsync(Guid userId, string skillName)
        {
            var user = await _context.Users
                .Include(u => u.Skills)
                .FirstOrDefaultAsync(u => u.UserId == userId);

            if (user == null)
            {
                throw new UserNotFoundException(nameof(User), userId);
            }

            // Check if the skill already exists
            var existingSkill = await _context.Skills.FirstOrDefaultAsync(s => s.SkillName == skillName);

            if (existingSkill == null)
            {
                // If the skill doesn't exist, create it
                var newSkill = new Skill { SkillName = skillName };
                _context.Skills.Add(newSkill);
                await _context.SaveChangesAsync();
                user.Skills.Add(newSkill);
            }
            else
            {
                // If the skill already exists, add it to the user
                user.Skills.Add(existingSkill);
            }

            await _context.SaveChangesAsync();
        }

        public async Task RemoveSkillFromUserAsync(Guid userId, int skillId)
        {
            var user = await _context.Users
                .Include(u => u.Skills)
                .FirstOrDefaultAsync(u => u.UserId == userId);

            if (user == null)
            {
                throw new UserNotFoundException(nameof(User), userId);
            }

            var skill = await _context.Skills.FindAsync(skillId);

            if (skill == null)
            {
                throw new EntityNotFoundException(nameof(Skill), skillId);
            }

            if (user.Skills.Contains(skill))
            {
                user.Skills.Remove(skill);
                await _context.SaveChangesAsync();
            }
        }

        //PortfolioProjects
        public async Task<ICollection<PortfolioProject>> GetUserPortfolioProjectsAsync(Guid userId)
        {
            var user = await _context.Users
                .Include(u => u.PortfolioProjects)
                .FirstOrDefaultAsync(pp => pp.UserId == userId);

            if (user is null)
                throw new UserNotFoundException(nameof(User), userId);

            return user.PortfolioProjects;
        }

        public async Task<PortfolioProject> GetPortfolioProjectByIdAsync(Guid userId, int portfolioProjectId)
        {
            var user = await _context.Users
                .Include(u => u.PortfolioProjects)
                .FirstOrDefaultAsync(u => u.UserId == userId);
            
            if (user == null)
            {
                throw new UserNotFoundException(nameof(User), userId);
            }

            var portfolioProject = user.PortfolioProjects.FirstOrDefault(pp => pp.PortfolioProjectId == portfolioProjectId);

            if (portfolioProject == null)
            {
                throw new EntityNotFoundException(nameof(PortfolioProject), portfolioProjectId);
            }

            return portfolioProject;
        }

        public async Task AddNewPortfolioProjectToUserAsync(Guid userId, string portfolioProjectName, string portfolioProjectDescription, string imageUrl, DateTime startDate, DateTime endDate)
        {
            var user = await _context.Users
                .Include(u => u.PortfolioProjects)
                .FirstOrDefaultAsync(u => u.UserId == userId);

            if (user == null)
            {
                throw new UserNotFoundException(nameof(User), userId);
            }

            // Check if the user already has the same project (based on name, description, URL, start date, and end date)
            var existingPortfolioProject = user.PortfolioProjects
                .FirstOrDefault(pp => pp.PortfolioProjectName == portfolioProjectName &&
                                     pp.PortfolioProjectDescription == portfolioProjectDescription &&
                                     pp.ImageUrl == imageUrl &&
                                     pp.StartDate == startDate &&
                                     pp.EndDate == endDate);

            if (existingPortfolioProject == null)
            {
                // Create a new PortfolioProject if it doesn't exist
                var newPortfolioProject = new PortfolioProject
                {
                    PortfolioProjectName = portfolioProjectName,
                    PortfolioProjectDescription = portfolioProjectDescription,
                    ImageUrl = imageUrl,
                    StartDate = startDate,
                    EndDate = endDate
                };

                _context.PortfolioProjects.Add(newPortfolioProject);
                user.PortfolioProjects.Add(newPortfolioProject);
                await _context.SaveChangesAsync();
            }
            else
            {
                user.PortfolioProjects.Add(existingPortfolioProject);
            }

            await _context.SaveChangesAsync();
        }

        public async Task RemovePortfolioProjectFromUserAsync(Guid userId, int portfolioProjectId)
        {
            var user = await _context.Users
                .Include(u => u.PortfolioProjects)
                .FirstOrDefaultAsync(u => u.UserId == userId);

            if (user == null)
            {
                throw new UserNotFoundException(nameof(User), userId);
            }

            var portfolioProject = await _context.PortfolioProjects.FindAsync(portfolioProjectId);

            if (portfolioProject == null)
            {
                throw new EntityNotFoundException(nameof(PortfolioProject), portfolioProjectId);
            }

            if (user.PortfolioProjects.Contains(portfolioProject))
            {
                user.PortfolioProjects.Remove(portfolioProject);
                await _context.SaveChangesAsync();
            }
        }

        //Projects
        public async Task<ICollection<Project>> GetUserTeamMemberProjectsAsync(Guid userId)
        {
            var projects = await _context.ProjectUsers
            .Where(pu => pu.UserId == userId && pu.Role == "User")
            .Select(pu => pu.Projects)
            .ToListAsync();

            return projects;
        }

        public async Task<ICollection<Project>> GetUserOwnerProjectsAsync(Guid userId)
        {
            var projects = await _context.ProjectUsers
            .Where(pu => pu.UserId == userId && pu.Role == "Owner")
            .Select(pu => pu.Projects)
            .ToListAsync();

            return projects;
        }

        //Helping methods
        private async Task<bool> UserExistsAsync(Guid id)
        {
            return await _context.Users.AnyAsync(u => u.UserId == id);
        }
    }
}
