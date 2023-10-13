using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using Lagalt_Backend.Services.Projects;
using Lagalt_Backend.Data.Dtos.Projects;
using Lagalt_Backend.Data.Dtos.Messages;
using Lagalt_Backend.Data.Models.ProjectModels;
using Lagalt_Backend.Data.Exceptions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lagalt_Backend.Controllers
{
    /// <summary>
    /// API Controller for operations related to Projects.
    /// </summary>
    [Route("api/v1/projects")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectService _projService;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProjectsController"/> class.
        /// </summary>
        /// <param name="projService">The service object for accessing project operations.</param>
        /// <param name="mapper">The AutoMapper object for converting entity models to DTOs and vice versa.</param>
        public ProjectsController(IProjectService projService, IMapper mapper)
        {
            _projService = projService;
            _mapper = mapper;
        }

        /// <summary>
        /// Gets all projects.
        /// </summary>
        /// <returns>A list of projects.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjectDTO>>> GetProjects()
        {
            return Ok(_mapper
                .Map<IEnumerable<ProjectDTO>>(
                    await _projService.GetAllAsync()));
        }

        /// <summary>
        /// Gets a project by ID.
        /// </summary>
        /// <param name="id">The ID of the project.</param>
        /// <returns>The project DTO if found.</returns>
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

        /// <summary>
        /// Updates a given project.
        /// </summary>
        /// <param name="id">The ID of the project to update.</param>
        /// <param name="project">The project data to use for the update.</param>
        /// <returns>An IActionResult object.</returns>
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

        /// <summary>
        /// Creates a new project.
        /// </summary>
        /// <param name="project">The new project's data.</param>
        /// <returns>A newly created project.</returns>
        [HttpPost]
        public async Task<ActionResult<ProjectDTO>> PostProject(ProjectPostDTO project)
        {
            var newProj = await _projService.AddAsync(_mapper.Map<Project>(project));

            return CreatedAtAction("GetProject",
                new { id = newProj.ProjectId },
                _mapper.Map<ProjectDTO>(newProj));
        }

        /// <summary>
        /// Deletes a project by ID.
        /// </summary>
        /// <param name="id">The ID of the project to delete.</param>
        /// <returns>An IActionResult object.</returns>
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

        /// <summary>
        /// Gets messages for a specific project.
        /// </summary>
        /// <param name="id">The ID of the project.</param>
        /// <returns>A list of messages for the specified project.</returns>
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

        //Get message from project by id

        [HttpGet("{id}/messages/{messageId}")]
        public async Task<ActionResult<MessageDTO>> GetMessageFromProjectById(int id, int messageId)
        {
            try
            {
                var message = await _projService.GetMessageFromProjectByIdAsync(id, messageId);
                return Ok(_mapper.Map<MessageDTO>(message));
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        //Post message to project

    }
}
