using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using Lagalt_Backend.Services.Projects;
using Lagalt_Backend.Data.Dtos.Projects;
using Lagalt_Backend.Data.Dtos.Messages;
using Lagalt_Backend.Data.Models.ProjectModels;
using Lagalt_Backend.Data.Exceptions;

namespace Lagalt_Backend.Controllers
{
    [Route("api/v1/projects")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectService _projService;
        private readonly IMapper _mapper;

        public ProjectsController(IProjectService projService, IMapper mapper)
        {
            _projService = projService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjectDTO>>> GetProjects()
        {
            return Ok(_mapper
                .Map<IEnumerable<ProjectDTO>>(
                    await _projService.GetAllAsync()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectDTO>> GetProject(int id)
        {
            try
            {
                return Ok(_mapper
                    .Map<ProjectDTO>(
                        await _projService.GetByIdAsync(id)));
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutProject(int id, ProjectPutDTO project)
        {
            if (id != project.ProjectId)
            {
                return BadRequest();
            }

            try
            {
                await _projService.UpdateAsync(_mapper.Map<Project>(project));
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<ProjectDTO>> PostProject(ProjectPostDTO project)
        {
            var newProj = await _projService.AddAsync(_mapper.Map<Project>(project));

            return CreatedAtAction("GetProject",
                new { id = newProj.ProjectId },
                _mapper.Map<ProjectDTO>(newProj));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProject(int id)
        {
            try
            {
                await _projService.DeleteByIdAsync(id);
                return NoContent();
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        //Messages
        [HttpGet("{id}/messages")]
        public async Task<ActionResult<IEnumerable<MessageDTO>>> GetMessages(int id)
        {
            try
            {
                return Ok(_mapper
                    .Map<IEnumerable<MessageDTO>>(
                        await _projService.GetMessagesAsync(id)));
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
