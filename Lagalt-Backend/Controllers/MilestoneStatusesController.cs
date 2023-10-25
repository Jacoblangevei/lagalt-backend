using AutoMapper;
using Lagalt_Backend.Data.Dtos.Project.Milestones;
using Lagalt_Backend.Data.Dtos.Project.ProjectStatuses;
using Lagalt_Backend.Services.Projects.MilestoneStatuses;
using Lagalt_Backend.Services.Projects.ProjectStatuses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Lagalt_Backend.Controllers
{
    [Route("api/v1/milestonestatuses")]
    [ApiController]
    [Authorize]
    [Produces(MediaTypeNames.Application.Json)]
    [ApiConventionType(typeof(DefaultApiConventions))]
    [EnableCors("MyAllowSpecificOrigins")]
    public class MilestoneStatusesController : ControllerBase
    {
        private readonly IMilestoneStatusService _milestoneStatusService;
        private readonly IMapper _mapper;

        public MilestoneStatusesController(IMilestoneStatusService milestoneStatusService, IMapper mapper)
        {
            _milestoneStatusService = milestoneStatusService;
            _mapper = mapper;
        }

        /// <summary>
        /// Gets all milestone statuses milestones can have
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<List<MilestoneStatusDTO>>> GetAllMilestoneStatuses()
        {
            var milestoneStatuses = await _milestoneStatusService.GetAllMilestoneStatusesAsync();

            // Map the retrieved statuses to DTOs if needed
            var statusDtos = _mapper.Map<List<MilestoneStatusDTO>>(milestoneStatuses);

            return Ok(statusDtos);
        }
    }
}
