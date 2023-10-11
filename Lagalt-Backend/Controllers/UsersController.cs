using AutoMapper;
using Lagalt_Backend.Services.Users;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using Lagalt_Backend.Data.Dtos.Users;
using Lagalt_Backend.Data.Models.UserModels;
using Lagalt_Backend.Data.Dtos.Skills;
using Lagalt_Backend.Data.Dtos.Projects;
using Lagalt_Backend.Data.Exceptions;
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

        //Skill section

        /// <summary>
        /// Adds a skill to the user.
        /// </summary>
        /// <remarks>
        /// TODO: Expand the controller methods for handling skills.
        /// </remarks>
        /// <param name="skill">The skill data to add.</param>
        /// <returns>A newly created skill.</returns>
        [HttpPost("skill")]
        public async Task<ActionResult<SkillDTO>> PostSkill(SkillPostDTO skill)
        {
            var newSkill = await _userService.AddSkillAsync(_mapper.Map<Skill>(skill));

            return CreatedAtAction("GetUser",
                new { id = newSkill.SkillId },
                _mapper.Map<SkillDTO>(newSkill));
        }
    }
}
