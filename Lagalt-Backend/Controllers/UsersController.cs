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

namespace Lagalt_Backend.Controllers
{
    [Route("api/v1/users")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [ApiConventionType(typeof(DefaultApiConventions))]


    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UsersController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetUsers()
        {
            return Ok(_mapper
                .Map<IEnumerable<UserDTO>>(
                    await _userService.GetAllAsync()));
        }

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

        [HttpPost]
        public async Task<ActionResult<UserDTO>> PostUser(UserPostDTO user)
        {
            var newUser = await _userService.AddAsync(_mapper.Map<User>(user));

            return CreatedAtAction("GetUser",
                new { id = newUser.UserId },
                _mapper.Map<UserDTO>(newUser));
        }

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


        [HttpGet("{id}/skills/{skillId}")]
        public async Task<ActionResult<SkillDTO>> GetSkillById(int userId, int skillId)
        {
            try
            {
                var skill = await _userService.GetSkillByIdAsync(userId, skillId);
                return Ok(_mapper.Map<SkillDTO>(skill));
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost("{id}/skills")]
        public async Task<IActionResult> AddNewSkillToUser(int userId, [FromBody] SkillPostDTO skillPostDto)
        {
            try
            {
                await _userService.AddNewSkillToUserAsync(userId, skillPostDto.SkillName);
                return Ok("Skill added to user successfully.");
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}/skills/{skillId}")]
        public async Task<ActionResult> RemoveSkillFromUser(int userId, int skillId)
        {
            try
            {
                await _userService.RemoveSkillFromUserAsync(userId, skillId);
                return Ok("Skill removed from user successfully.");
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        //Portfolio Projects
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

        [HttpPost("{userId}/portfolioprojects")]
        public async Task<IActionResult> AddPortfolioProjectToUser(int userId, [FromBody] PortfolioProjectPostDTO projectDTO)
        {
            try
            {
                await _userService.AddNewPortfolioProjectToUserAsync(userId, projectDTO.PortfolioProjectName, projectDTO.PortfolioProjectDescription, projectDTO.ImageUrl, projectDTO.StartDate, projectDTO.EndDate);
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

        [HttpDelete("{userId}/portfolioprojects/{portfolioProjectId}")]
        public async Task<ActionResult> RemovePortfolioProjectFromUser(int userId, int portfolioProjectId)
        {
            try
            {
                await _userService.RemovePortfolioProjectFromUserAsync(userId, portfolioProjectId);
                return Ok("Portfolio project removed from user successfully.");
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
