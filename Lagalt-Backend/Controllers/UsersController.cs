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

namespace Lagalt_Backend.Controllers
{
    /// <summary>
    /// API Controller for operations related to Users.
    /// </summary>
    [Route("api/v1/users")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="UsersController"/> class.
        /// </summary>
        /// <param name="userService">The service object for accessing user operations.</param>
        /// <param name="mapper">The AutoMapper object for converting entity models to DTOs and vice versa.</param>
        public UsersController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        /// <summary>
        /// Gets all users.
        /// </summary>
        /// <returns>A list of users.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetUsers()
        {
            return Ok(_mapper
                .Map<IEnumerable<UserDTO>>(
                    await _userService.GetAllAsync()));
        }

        /// <summary>
        /// Gets a user by ID.
        /// </summary>
        /// <param name="id">The ID of the user.</param>
        /// <returns>The user DTO if found.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> GetUser(int id)
        {
            try
            {
                return Ok(_mapper
                    .Map<UserDTO>(
                        await _userService.GetByIdAsync(id)));
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        /// <summary>
        /// Creates a new user.
        /// </summary>
        /// <param name="user">The user data to create.</param>
        /// <returns>A newly created user.</returns>
        [HttpPost("user")]
        public async Task<ActionResult<UserDTO>> PostUser(UserPostDTO user)
        {
            var newUser = await _userService.AddAsync(_mapper.Map<User>(user));

            return CreatedAtAction("GetUser",
                new { id = newUser.UserId },
                _mapper.Map<UserDTO>(newUser));
        }
        
        //Might not working properly anymore
        /// <summary>
        /// Gets the profile of a specific user.
        /// </summary>
        /// <param name="id">The ID of the user.</param>
        /// <returns>The user's profile DTO.</returns>
        [HttpGet("{id}/profile")]
        public async Task<ActionResult<UserProfileDTO>> GetUserProfile(int id)
        {
            var user = await _userService.GetByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            var userProfileDto = _mapper.Map<UserProfileDTO>(user);

            return Ok(userProfileDto);
        }

        //Skill

        /// <summary>
        /// Gets all skills a user has
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}/skills")]
        public async Task<ActionResult<IEnumerable<SkillDTO>>> GetSkills(int id)
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
        public async Task<ActionResult<SkillDTO>> GetSkillById(int id, int skillId)
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
        [HttpPost("{id}/skills")]
        public async Task<IActionResult> AddNewSkillToUser(int id, [FromBody] SkillPostDTO skillPostDto)
        {
            try
            {
                await _userService.AddNewSkillToUserAsync(id, skillPostDto.SkillName);
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
        public async Task<ActionResult> RemoveSkillFromUser(int id, int skillId)
        {
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
        public async Task<ActionResult<IEnumerable<PortfolioProjectDTO>>> GetPortfolioProjects(int id)
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
        public async Task<ActionResult<PortfolioProjectDTO>> GetPortfolioProjectById(int id, int portfolioProjectId)
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
        public async Task<IActionResult> AddPortfolioProjectToUser(int id, [FromBody] PortfolioProjectPostDTO projectDTO)
        {
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
        public async Task<ActionResult> RemovePortfolioProjectFromUser(int id, int portfolioProjectId)
        {
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
    }
}
