using AutoMapper;
using Lagalt_Backend.Services.Users;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using Lagalt_Backend.Data.Dtos.Users;
using Lagalt_Backend.Data.Models.UserModels;
using Lagalt_Backend.Data.Dtos.Skills;
using Lagalt_Backend.Data.Dtos.Projects;
using Lagalt_Backend.Data.Exceptions;

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

        [HttpPost("user")]
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

        //Todo: Make more skill controller methods so that the post will work
        [HttpPost("skill")]
        public async Task<ActionResult<SkillDTO>> PostSkill(SkillPostDTO skill)
        {
            var newSkill = await _userService.AddSkillAsync(_mapper.Map<Skill>(skill));

            return CreatedAtAction("GetUser",
                new { id = newSkill.SkillId },
                _mapper.Map<UserDTO>(newSkill));
        }
    }
}
