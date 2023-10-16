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
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Lagalt_Backend.Data.Dtos.Tags;

namespace Lagalt_Backend.Controllers
{
    /// <summary>
    /// API Controller for operations related to Projects.
    /// </summary>
    [Route("api/v1/projects")]
    [ApiController]
    [Authorize]
    [Produces(MediaTypeNames.Application.Json)]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectService _projService;
        private readonly IProjectTypeService _projectTypeService;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProjectsController"/> class.
        /// </summary>
        /// <param name="projService">The service object for accessing project operations.</param>
        /// <param name="mapper">The AutoMapper object for converting entity models to DTOs and vice versa.</param>
        public ProjectsController(IProjectService projService, IProjectTypeService projectTypeService, IMapper mapper)
        {
            _projService = projService;
            _projectTypeService = projectTypeService;
            _mapper = mapper;
        }

        /// <summary>
        /// Gets all projects.
        /// </summary>
        /// <returns>A list of projects.</returns>
        [HttpGet]
        [AllowAnonymous]
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
        [AllowAnonymous]
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
        /// <returns></returns>
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutProject(int id, ProjectPutDTO project)
        {

            string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            Project existingProject = await _projService.GetByIdAsync(id);

            if (existingProject == null)
            {
                return NotFound();
            }

            if (existingProject.OwnerId != Guid.Parse(userId))
            {
                return Forbid();
            }

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
        [Authorize]
        public async Task<ActionResult<ProjectDTO>> PostProject([FromBody] ProjectPostDTO projectPostDTO)
        {
            try
            {
                string ownerId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                ProjectType projectType = await _projectTypeService.GetByIdAsync(projectPostDTO.ProjectTypeId.Value);

                var newProject = new Project
                {
                    Name = projectPostDTO.Name,
                    Description = projectPostDTO.Description,
                    ImageUrl = projectPostDTO.ImageUrl,
                    ProjectType = projectType
                };

                var createdProject = await _projService.CreateProjectAsync(newProject, Guid.Parse(ownerId));
                var projectDTO = _mapper.Map<ProjectDTO>(createdProject);

                return CreatedAtAction("GetProject", new { id = projectDTO.ProjectId }, projectDTO);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        /// <summary>
        /// Deletes a project by ID.
        /// </summary>
        /// <param name="id">The ID of the project to delete.</param>
        /// <returns>An IActionResult object.</returns>
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteProject(int id)
        {
            string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            Project existingProject = await _projService.GetByIdAsync(id);

            if (existingProject == null)
            {
                return NotFound();
            }

            if (existingProject.OwnerId != Guid.Parse(userId))
            {
                return Forbid();
            }

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

        //Tags

        /// <summary>
        /// Get all tags in a project
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}/tags")]
        [AllowAnonymous]
        public async Task<ActionResult> GetAllTagsInProject(int id)
        {
            try
            {
                var tags = await _projService.GetAllTagsInProjectAsync(id);
                return Ok(tags);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        /// <summary>
        /// Get a tag in a project by id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="tagId"></param>
        /// <returns></returns>
        [HttpGet("{id}/tags/{tagId}")]
        [AllowAnonymous]
        public async Task<ActionResult> GetTagInProject(int id, int tagId)
        {
            try
            {
                var tag = await _projService.GetTagInProjectByIdAsync(id, tagId);
                return Ok(tag);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        /// <summary>
        /// Adding tags to a project
        /// </summary>
        /// <param name="projectId"></param>
        /// <param name="tagIds"></param>
        /// <returns>If owner, a NoContent</returns>
        [HttpPost("{id}/tags/add")]
        [Authorize]
        public async Task<IActionResult> AddTagToProject(int id, [FromBody] TagPostDTO tagPostDTO)
        {
            string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            Project existingProject = await _projService.GetByIdAsync(id);

            if (existingProject == null)
            {
                return NotFound();
            }

            if (existingProject.OwnerId != Guid.Parse(userId))
            {
                return Forbid();
            }

            try
            {
                await _projService.AddTagToProjectAsync(id, tagPostDTO.TagName);
                return NoContent();
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        /// <summary>
        /// Removes a tag from project
        /// </summary>
        /// <param name="projectId"></param>
        /// <param name="tagId"></param>
        /// <returns>If project owner, no content</returns>
        [HttpDelete("{projectId}/tags/remove/{tagId}")]
        [Authorize]
        public async Task<IActionResult> RemoveTag(int projectId, int tagId)
        {
            string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            Project existingProject = await _projService.GetByIdAsync(projectId);

            if (existingProject == null)
            {
                return NotFound();
            }

            if (existingProject.OwnerId != Guid.Parse(userId))
            {
                return Forbid();
            }

            try
            {
                await _projService.RemoveTagFromProjectAsync(projectId, tagId);
                return NoContent();
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        //Requirements Working on it
          

        //Messages Not correct
        /// <summary>
        /// Gets messages for a specific project.
        /// </summary>
        /// <param name="id">The ID of the project.</param>
        /// <returns>A list of messages for the specified project.</returns>
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
        [HttpPost]
        [Route("{id}/message")]
        public async Task<IActionResult> AddMessageToProject(int id, [FromBody] MessagePostDTO messageDTO)
        {
            try
            {
                Guid userId = new Guid("00000000-0000-0000-0000-000000000001"); //Gonna get this from somehwee else later

                await _projService.AddNewMessageToProjectAsync(id, userId, messageDTO.Subject,messageDTO.MessageContent, messageDTO.ImageUrl);
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

    }
}
