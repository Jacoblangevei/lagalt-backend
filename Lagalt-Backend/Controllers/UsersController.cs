using AutoMapper;
using Lagalt_Backend.Services.Users;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using Lagalt_Backend.Data.Dtos.Users;
using Lagalt_Backend.Data.Models.UserModels;
using Lagalt_Backend.Data.Dtos.Skills;
using Lagalt_Backend.Data.Dtos.PortfolioProjects;
using Lagalt_Backend.Data.Exceptions;
using Azure.Core;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using System;
using Lagalt_Backend.Data;
using Lagalt_Backend.Data.Dtos.Projects;

namespace Lagalt_Backend.Controllers
{
    /// <summary>
    /// API Controller for operations related to Users.
    /// </summary>
    [Route("api/v1/users")]
    [ApiController]
    [Authorize]
    [Produces(MediaTypeNames.Application.Json)]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly LagaltDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="UsersController"/> class.
        /// </summary>
        /// <param name="userService">The service object for accessing user operations.</param>
        /// <param name="mapper">The AutoMapper object for converting entity models to DTOs and vice versa.</param>
        public UsersController(IUserService userService, IMapper mapper, LagaltDbContext context)
        {
            _userService = userService;
            _mapper = mapper;
            _context = context;
        }

        //New, not done, using keycloak
        /// <summary>
        /// Gets all users from the database
        /// </summary>
        /// <returns>A list of the DTOs if the users if found </returns>
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetUsers()
        {
            if (_context.Users == null)
            {
                return NotFound();
            }
            var users = await _context.Users.ToListAsync();

            var userDTOs = users.Select(user => _mapper.Map<UserDTO>(user)).ToList();
            return userDTOs;
        }

        //New, not done
        /// <summary>
        /// Gets a user by ID.
        /// </summary>
        /// <param name="id">The ID of the user.</param>
        /// <returns>The user DTO if found.</returns>
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<UserDTO>> GetUser(Guid id)
        {
            if (_context.Users == null)
            {
                return NotFound();
            }
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            var userDTO = _mapper.Map<UserDTO>(user);
            return userDTO;
        }

        /// <summary>
        /// Get the id from the database
        /// </summary>
        /// <returns></returns>
        [HttpPost("register")]
        [Authorize]
        public ActionResult<User> RegisterUser()
        {
            try
            {
                var claim = User.FindFirst(ClaimTypes.NameIdentifier);
                var usernameClaim = User.Claims.FirstOrDefault(claim => claim.Type == "preferred_username");
                string username = usernameClaim.Value;

                if (claim == null || !Guid.TryParse(claim.Value, out var userId))
                {
                    return BadRequest("Invalid user data.");
                }

                var existingUser = _context.Users.Find(userId);
                if (existingUser != null)
                {
                    return Ok("User is already registered.");
                }

                // Create a new user
                User user = new User
                {
                    UserId = userId,
                    UserName = username ?? "Unknown", //just in case
                    AnonymousModeOn = false
                };

                _context.Users.Add(user);
                _context.SaveChanges();

                return CreatedAtAction("GetUser", new { id = user.UserId }, user);
            }
            catch (Exception ex)
            {
                // Log the exception for debugging
                Console.WriteLine($"Error: {ex.Message}");
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        //New,not done
        //[HttpGet("exists")]
        //[AllowAnonymous]
        //public async Task<ActionResult<User>> GetIfExistsOrRegistrateToDatabase()
        //{
        //    string subject = User.FindFirst(ClaimTypes.NameIdentifier).Value;
        //    var user = _context.Users.Where(x => x.UserId.ToString() == subject).FirstOrDefault();

        //    if (user != null)
        //    {
        //        // User already exists in database, you can return an appropriate response.
        //        var userDTO = _mapper.Map<UserDTO>(user);
        //        return Ok(userDTO);
        //    }

        //    string username = User.FindFirst(ClaimTypes.Name).Value;
        //    // If the user doesn't exist, create a new user and add it to the database.
        //    User newUser = new User()
        //    {
        //        UserId = Guid.Parse(subject),
        //        UserName = username
        //    };

        //    _context.Users.Add(newUser);
        //    await _context.SaveChangesAsync();

        //    // Return the newly created user.
        //    var newUserDTO = _mapper.Map<UserDTO>(newUser);
        //    return CreatedAtAction("GetUser", new { id = newUser.UserId }, newUserDTO);
        //}

        //new, not done
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutAppUser(Guid id, [FromBody] UserPutDTO userPutDTO)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier);

            if (userId.Value != id.ToString())
            {
                return Forbid();
            }

            try
            {
                // Load the user from the database and update the properties.
                var user = await _context.Users.FindAsync(id);
                if (user == null)
                {
                    return NotFound();
                }

                user.Description = userPutDTO.Description;
                user.Education = userPutDTO.Education;

                // Save the changes to the database.
                await _context.SaveChangesAsync();

                return Ok("User updated successfully");
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }

        //New,not done
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<UserDTO>> PostUser(User user)
        {
            if (_context.Users == null)
            {
                return Problem("Entity set 'LagaltDbContext.Users'  is null.");
            }
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.UserId }, user);
        }


        private bool UserExists(Guid id)
        {
            return (_context.Users?.Any(e => e.UserId == id)).GetValueOrDefault();
        }

        //Skill

        /// <summary>
        /// Gets all skills a user has
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}/skills")]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<SkillDTO>>> GetSkills(Guid id)
        {
            try
            {
                var skills = await _userService.GetUserSkillsAsync(id);
                return Ok(_mapper.Map<IEnumerable<SkillDTO>>(skills));
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        /// <summary>
        /// Gets a spesific skill from user
        /// </summary>
        /// <param name="id"></param>
        /// <param name="skillId"></param>
        /// <returns></returns>
        [HttpGet("{id}/skills/{skillId}")]
        [AllowAnonymous]
        public async Task<ActionResult<SkillDTO>> GetSkillById(Guid id, int skillId)
        {
            try
            {
                var skill = await _userService.GetSkillByIdAsync(id, skillId);
                return Ok(_mapper.Map<SkillDTO>(skill));
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        /// <summary>
        /// Adds skill to user
        /// </summary>
        /// <param name="id"></param>
        /// <param name="skillPostDto"></param>
        /// <returns></returns>
        [HttpPost("skills")]
        [Authorize]
        public async Task<IActionResult> AddNewSkillToUser([FromBody] SkillPostDTO skillPostDto)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(userIdClaim))
            {
                // Handle the case where the user's ID is not available in the claims.
                return Unauthorized();
            }

            try
            {
                Guid userId = Guid.Parse(userIdClaim);
                await _userService.AddNewSkillToUserAsync(userId, skillPostDto.SkillName);
                return Ok("Skill added to user successfully.");
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        /// <summary>
        /// Removes skill from user
        /// </summary>
        /// <param name="id"></param>
        /// <param name="skillId"></param>
        /// <returns></returns>
        [HttpDelete("{id}/skills/{skillId}")]
        [Authorize]
        public async Task<ActionResult> RemoveSkillFromUser(Guid id, int skillId)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier);

            // Compare userId with id to ensure the user is working on their own data.
            if (userId.Value != id.ToString())
            {
                return Forbid(); // Return a 403 Forbidden status if access is denied.
            }

            try
            {
                await _userService.RemoveSkillFromUserAsync(id, skillId);
                return Ok("Skill removed from user successfully.");
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        //Portfolio Projects

        /// <summary>
        /// Gets all portfolio projecs a user has
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}/portfolioprojects")]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<PortfolioProjectDTO>>> GetPortfolioProjects(Guid id)
        {
            try
            {
                var portfolioProjects = await _userService.GetUserPortfolioProjectsAsync(id);
                return Ok(_mapper.Map<IEnumerable<PortfolioProjectDTO>>(portfolioProjects));
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        /// <summary>
        /// Gets a spesific portfolio project a user has
        /// </summary>
        /// <param name="id"></param>
        /// <param name="portfolioProjectId"></param>
        /// <returns></returns>
        [HttpGet("{id}/portfolioprojects/{portfolioProjectId}")]
        [AllowAnonymous]
        public async Task<ActionResult<PortfolioProjectDTO>> GetPortfolioProjectById(Guid id, int portfolioProjectId)
        {
            try
            {
                var portfolioProject = await _userService.GetPortfolioProjectByIdAsync(id, portfolioProjectId);
                return Ok(_mapper.Map<PortfolioProjectDTO>(portfolioProject));
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        /// <summary>
        /// Adds new portfolio project to user
        /// </summary>
        /// <param name="id"></param>
        /// <param name="projectDTO"></param>
        /// <returns></returns>
        [HttpPost("{id}/portfolioprojects")]
        [Authorize]
        public async Task<IActionResult> AddPortfolioProjectToUser(Guid id, [FromBody] PortfolioProjectPostDTO projectDTO)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier);

            // Compare userId with id to ensure the user is working on their own data.
            if (userId.Value != id.ToString())
            {
                return Forbid(); // Return a 403 Forbidden status if access is denied.
            }

            try
            {
                await _userService.AddNewPortfolioProjectToUserAsync(id, projectDTO.PortfolioProjectName, projectDTO.PortfolioProjectDescription, projectDTO.ImageUrl, projectDTO.StartDate, projectDTO.EndDate);
                return Ok("Portfolio project added to the user successfully.");
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Deletes portfolio project a user has
        /// </summary>
        /// <param name="id"></param>
        /// <param name="portfolioProjectId"></param>
        /// <returns></returns>
        [HttpDelete("{id}/portfolioprojects/{portfolioProjectId}")]
        [Authorize]
        public async Task<ActionResult> RemovePortfolioProjectFromUser(Guid id, int portfolioProjectId)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier);

            if (userId.Value != id.ToString())
            {
                return Forbid();
            }

            try
            {
                await _userService.RemovePortfolioProjectFromUserAsync(id, portfolioProjectId);
                return Ok("Portfolio project removed from user successfully.");
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        //Lagalt projects

        /// <summary>
        /// Gets all project user is a part of as user
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}/teammemberprojects")]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<ProjectDTO>>> GetTeamMemberProjects(Guid id)
        {
            try
            {
                var teamMemberProjects = await _userService.GetUserTeamMemberProjectsAsync(id);
                return Ok(_mapper.Map<IEnumerable<ProjectDTO>>(teamMemberProjects));
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        /// <summary>
        /// Gets all projects user owns
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}/ownerprojects")]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<ProjectDTO>>> GetOwnerProjects(Guid id)
        {
            try
            {
                var ownerProjects = await _userService.GetUserOwnerProjectsAsync(id);
                return Ok(_mapper.Map<IEnumerable<ProjectDTO>>(ownerProjects));
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        private bool UserHasAccessToUser(Guid id)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (userIdClaim != null)
            {
                Guid authenticatedUserId = Guid.Parse(userIdClaim);
                return authenticatedUserId == id;
            }

            return false;
        }
    }
}
