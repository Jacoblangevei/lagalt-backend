using AutoMapper;
using Lagalt_Backend.Data.Dtos.Project.ProjectStatuses;
using Lagalt_Backend.Services.Projects.ProjectStatuses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Lagalt_Backend.Controllers
{
    [Route("api/v1/statuses")]
    [ApiController]
    [Authorize]
    [Produces(MediaTypeNames.Application.Json)]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class ProjectStatusesController : ControllerBase
    {
        private readonly IProjectStatusService _projectStatusService;
        private readonly IMapper _mapper;

        public ProjectStatusesController(IProjectStatusService projectStatusService, IMapper mapper)
        {
            _projectStatusService = projectStatusService;
            _mapper = mapper;
        }

        /// <summary>
        /// Gets all project statuses projects can have
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<List<ProjectStatusDTO>>> GetAllProjectStatuses()
        {
            var projectStatuses = await _projectStatusService.GetAllProjectStatusesAsync();

            // Map the retrieved statuses to DTOs if needed
            var statusDtos = _mapper.Map<List<ProjectStatusDTO>>(projectStatuses);

            return Ok(statusDtos);
        }
    }
}
