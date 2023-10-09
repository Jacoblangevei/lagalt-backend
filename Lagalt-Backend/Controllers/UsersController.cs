using AutoMapper;
using Lagalt_Backend.Services.Users;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

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
    }
}
