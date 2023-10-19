using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using Lagalt_Backend.Services.Projects;
using Lagalt_Backend.Data.Dtos.Projects;
using Lagalt_Backend.Data.Dtos.ProjectRequests;
using Lagalt_Backend.Data.Dtos.Messages;
using Lagalt_Backend.Data.Models.ProjectModels;
using Lagalt_Backend.Data.Exceptions;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Lagalt_Backend.Data.Dtos.Tags;
using Lagalt_Backend.Data.Dtos.Requirements;
using Lagalt_Backend.Data.Models.MessageModels;
using Lagalt_Backend.Data.Models.UserModels;
using Lagalt_Backend.Services.ProjectRequests;
using Microsoft.EntityFrameworkCore;
using Lagalt_Backend.Services.Projects.Messages;
using Lagalt_Backend.Services.Projects.Updates;
using Lagalt_Backend.Data.Dtos.Project.Updates;
using Lagalt_Backend.Services.Projects.ProjectStatuses;
using System;
using Lagalt_Backend.Services.Projects.Milestones;
using Lagalt_Backend.Data.Dtos.Project.Milestones;

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
        private readonly IProjectRequestService _projectRequestService;
        private readonly IMessageProjectService _messageProjectService;
        private readonly IUpdateService _updateService;
        private readonly IProjectStatusService _projectStatusService;
        private readonly IMilestoneService _milestoneService;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProjectsController"/> class.
        /// </summary>
        /// <param name="projService">The service object for accessing project operations.</param>
        /// <param name="mapper">The AutoMapper object for converting entity models to DTOs and vice versa.</param>
        public ProjectsController(IProjectService projService, IProjectTypeService projectTypeService, IMapper mapper, IProjectRequestService projectRequestService, IUpdateService updateService, IProjectStatusService projectStatusService, IMessageProjectService messageProjectService)
        {
            _projService = projService;
            _projectTypeService = projectTypeService;
            _projectRequestService = projectRequestService;
            _updateService = updateService;
            _projectStatusService = projectStatusService;
            _messageProjectService = messageProjectService;
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
        public async Task<ActionResult<ProjectDTO>> GetProject([FromRoute] int id)
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
        /// Updates project
        /// </summary>
        /// <param name="id"></param>
        /// <param name="projectPutDTO"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> PutProject(int id, [FromBody] ProjectPutDTO projectPutDTO)
        {
            //string userId = "00000000-0000-0000-0000-000000000001";
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

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
                // Update project details
                existingProject.Name = projectPutDTO.Name;
                existingProject.Description = projectPutDTO.Description;
                existingProject.ImageUrl = projectPutDTO.ImageUrl;

                // Check if the status is being updated
                if (existingProject.ProjectStatusId != projectPutDTO.ProjectStatusId)
                {
                    // Ensure that the selected status exists
                    var statusExists = await _projectStatusService.ProjectStatusExistsAsync(projectPutDTO.ProjectStatusId);
                    if (!statusExists)
                    {
                        return BadRequest("Invalid project status.");
                    }

                    existingProject.ProjectStatusId = projectPutDTO.ProjectStatusId;
                }

                // Call the service to save changes
                await _projService.UpdateAsync(existingProject);

                return NoContent();
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
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
                var ownerId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                ProjectType projectType = await _projectTypeService.GetByIdAsync(projectPostDTO.ProjectTypeId.Value);

                var newProject = new Project
                {
                    Name = projectPostDTO.Name,
                    Description = projectPostDTO.Description,
                    ImageUrl = projectPostDTO.ImageUrl,
                    ProjectType = projectType,
                    ProjectStatusId = 1,
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
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

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
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

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
        [HttpDelete("{id}/tags/remove/{tagId}")]
        [Authorize]
        public async Task<IActionResult> RemoveTag(int id, int tagId)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

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
                await _projService.RemoveTagFromProjectAsync(id, tagId);
                return NoContent();
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        //Requirements

        /// <summary>
        /// Gets all requirements in a project
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}/requirements")]
        [AllowAnonymous]
        public async Task<ActionResult> GetAllRequirementsInProject(int id)
        {
            try
            {
                var requirements = await _projService.GetAllRequirementsInProjectAsync(id);
                return Ok(requirements);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        /// <summary>
        /// Gets requirement from project
        /// </summary>
        /// <param name="id"></param>
        /// <param name="requirementId"></param>
        /// <returns></returns>
        [HttpGet("{id}/requirements/{requirementId}")]
        [AllowAnonymous]
        public async Task<ActionResult> GetRequirementInProject(int id, int requirementId)
        {
            try
            {
                var requirement = await _projService.GetRequirementInProjectByIdAsync(id, requirementId);
                return Ok(requirement);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        /// <summary>
        /// Adds requirement to project
        /// </summary>
        /// <param name="id"></param>
        /// <param name="requirementPostDTO"></param>
        /// <returns></returns>
        [HttpPost("{id}/requirements/add")]
        [Authorize]
        public async Task<IActionResult> AddRequirementToProject(int id, [FromBody] RequirementPostDTO requirementPostDTO)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

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
                await _projService.AddTagToProjectAsync(id, requirementPostDTO.RequirementText);
                return NoContent();
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        /// <summary>
        /// Removes requirement from project
        /// </summary>
        /// <param name="id"></param>
        /// <param name="requirementId"></param>
        /// <returns></returns>
        [HttpDelete("{id}/requirements/remove/{requirementId}")]
        [Authorize]
        public async Task<IActionResult> RemoveRequirement(int id, int requirementId)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

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
                await _projService.RemoveRequirementFromProjectAsync(id, requirementId);
                return NoContent();
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        //Messages

        /// <summary>
        /// Gets all messages in project
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}/messages")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllMessagesInProject(int id)
        {
            try
            {
                if (_messageProjectService == null)
                {
                    return NotFound("Message project service is not available.");
                }

                var messages = await _messageProjectService.GetAllMessagesInProjectAsync(id);

                if (_mapper == null)
                {
                    return NotFound("Mapper is not available.");
                }

                var messageDtos = _mapper.Map<List<MessageDTO>>(messages);

                return Ok(messageDtos);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        /// <summary>
        /// Gets message in project by id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="messageId"></param>
        /// <returns></returns>
        [HttpGet("{id}/messages/{messageId}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetMessageInProjectById(int id, int messageId)
        {
            try
            {
                var message = await _messageProjectService.GetMessageInProjectByIdAsync(id, messageId);
                var messageDto = _mapper.Map<MessageDTO>(message);

                return Ok(messageDto);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        /// <summary>
        /// Adds message to project
        /// </summary>
        /// <param name="id"></param>
        /// <param name="messagePostDTO"></param>
        /// <returns></returns>
        [HttpPost("{id}/messages")]
        [Authorize]
        public async Task<IActionResult> AddMessageToProject(int id, [FromBody] MessagePostDTO messagePostDTO)
        {
            //string userId = "00000000-0000-0000-0000-000000000001";

            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(userId))
            {
                return Forbid("User ID from Keycloak is missing or invalid.");
            }

            var newMessage = new Message
            {
                Subject = messagePostDTO.Subject,
                MessageContent = messagePostDTO.MessageContent,
                ImageUrl = messagePostDTO.ImageUrl,
                Timestamp = DateTime.UtcNow,
                UserId = Guid.Parse(userId),
                ProjectId = id,
            };

            newMessage.ParentId = null;

            var addedMessage = await _messageProjectService.AddMessageToProjectAsync(id, newMessage);

            return Ok(addedMessage);
        }

        //Requests

        /// <summary>
        /// Request to join project
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>
        [HttpPost("{projectId}/requests")]
        [Authorize]
        public async Task<IActionResult> RequestToJoinProject(int projectId)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            DateTime requestDate = DateTime.UtcNow;

            Project existingProject = await _projService.GetByIdAsync(projectId);

            if (existingProject == null)
            {
                return NotFound("Project not found.");
            }

            // Check if the user is already a member of the project
            bool isMember = await _projectRequestService.IsUserMemberOfProject(userId, projectId);

            // Check if the user has already sent a request
            bool hasSentRequest = await _projectRequestService.HasUserSentRequest(userId, projectId);

            if (isMember)
            {
                return BadRequest("User is already a member of the project.");
            }

            if (hasSentRequest)
            {
                return BadRequest("User has already sent a request to join the project.");
            }

            var projectRequest = new ProjectRequest
            {
                UserId = Guid.Parse(userId),
                ProjectId = projectId,
                RequestDate = requestDate
            };

            var result = await _projectRequestService.CreateRequestAsync(projectRequest);

            var responseDto = _mapper.Map<ProjectRequestDTO>(result);

            return CreatedAtAction(nameof(GetProjectRequests), new { projectId = projectId }, responseDto);
        }

        /// <summary>
        /// Get all requests a project has
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>
        [HttpGet("{projectId}/requests")]
        [Authorize]
        public async Task<IActionResult> GetProjectRequests(int projectId)
        {
            //string userId = "00000000-0000-0000-0000-000000000001";

            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            Project existingProject = await _projService.GetByIdAsync(projectId);

            if (existingProject == null)
            {
                return NotFound();
            }

            if (existingProject.OwnerId != Guid.Parse(userId))
            {
                return Forbid();
            }

            var requests = await _projectRequestService.GetAllRequestsForProjectAsync(projectId);

            if (requests == null || !requests.Any())
            {
                return NoContent();
            }

            var requestDtos = _mapper.Map<IEnumerable<ProjectRequestDTO>>(requests);

            return Ok(requestDtos);
        }

        /// <summary>
        /// Removes a request from project
        /// </summary>
        /// <param name="projectId"></param>
        /// <param name="requestId"></param>
        /// <returns></returns>
        [HttpDelete("{projectId}/requests/{requestId}")]
        [Authorize]
        public async Task<ActionResult> RemoveRequestFromProject(int projectId, int requestId)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

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
                await _projectRequestService.RemoveProjectFromProjectAsync(projectId, requestId);
                return Ok("Request removed from project successfully.");
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        /// <summary>
        /// Accepts request and adds user to project
        /// </summary>
        /// <param name="projectId"></param>
        /// <param name="requestId"></param>
        /// <returns></returns>
        [HttpPost("projects/{projectId}/requests/{requestId}/accept")]
        [Authorize]
        public async Task<IActionResult> AcceptRequest(int projectId, int requestId)
        {
            //string userId = "00000000-0000-0000-0000-000000000001";
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (projectId <= 0 || requestId <= 0)
            {
                return BadRequest("Invalid project ID or request ID.");
            }

            // Check if a project with the specified project ID exists
            Project existingProject = await _projService.GetByIdAsync(projectId);

            if (existingProject == null)
            {
                return NotFound("Project not found.");
            }

            if (existingProject.OwnerId != Guid.Parse(userId))
            {
                return Forbid("Only the project owner can accept requests.");
            }

            // Call the service method to accept the request
            var result = await _projectRequestService.AcceptRequestAsync(projectId, requestId);

            if (result)
            {
                return Ok("Request accepted.");
            }

            return NotFound("Request not found or an error occurred.");
        }

        //Updates

        /// <summary>
        /// Gets all updates in a project
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}/updates")]
        [Authorize]
        public async Task<IActionResult> GetAllUpdatesInProject(int id)
        {
            try
            {
                var updates = await _updateService.GetAllUpdatesInProjectAsync(id);
                var updateDtos = _mapper.Map<List<UpdateDTO>>(updates);

                return Ok(updateDtos);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        /// <summary>
        /// Gets one update in a project by id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updateId"></param>
        /// <returns></returns>
        [HttpGet("{id}/updates/{updateId}")]
        [Authorize]
        public async Task<IActionResult> GetUpdateInProjectById(int id, int updateId)
        {
            try
            {
                var update = await _updateService.GetUpdateInProjectByIdAsync(id, updateId);
                var updateDto = _mapper.Map<UpdateDTO>(update);

                return Ok(updateDto);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        /// <summary>
        /// Adds update to project
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updatePostDTO"></param>
        /// <returns></returns>
        [HttpPost("{id}/updates")]
        [Authorize]
        public async Task<IActionResult> AddUpdateToProject(int id, [FromBody] UpdatePostDTO updatePostDTO)
        {
            //string userId = "00000000-0000-0000-0000-000000000001";
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            //Guid userGuid = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

            var newUpdate = new Update
            {
                Description = updatePostDTO.Description,
                Timestamp = DateTime.UtcNow,
                UserId = Guid.Parse(userId),
                ProjectId = id
            };

            var addedUpdate = await _updateService.AddUpdateToProjectAsync(id, newUpdate);

            return Ok(addedUpdate);
        }

        //Milestones

        /// <summary>
        /// Gets all milestones in a project
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}/milestones")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllMilestonesInProject(int id)
        {
            try
            {
                var milestones = await _milestoneService.GetAllMilestonesInProjectAsync(id);
                var milestoneDtos = _mapper.Map<List<MilestoneDTO>>(milestones);

                return Ok(milestoneDtos);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        /// <summary>
        /// Gets one milestone in a project by id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="milestoneId"></param>
        /// <returns></returns>
        [HttpGet("{id}/milestones/{milestoneId}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetMilestoneInProjectById(int id, int milestoneId)
        {
            try
            {
                var milestone = await _milestoneService.GetMilestoneInProjectByIdAsync(id, milestoneId);
                var milestoneDto = _mapper.Map<MilestoneDTO>(milestone);

                return Ok(milestoneDto);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        /// <summary>
        /// Adds update to project
        /// </summary>
        /// <param name="id"></param>
        /// <param name="milestonePostDTO"></param>
        /// <returns></returns>
        [HttpPost("{id}/milestones")]
        [AllowAnonymous]
        public async Task<IActionResult> AddMilestoneToProject(int id, [FromBody] MilestonePostDTO milestonePostDTO)
        {

            var newMilestone = new Milestone
            {
                Title = milestonePostDTO.Title,
                Description = milestonePostDTO.Description,
                DueDate = DateTime.UtcNow,
                Currency = milestonePostDTO.Currency,
                PaymentAmount = milestonePostDTO.PaymentAmount,
                ProjectId = id
            };

            var addedMilestone = await _milestoneService.AddMilestoneToProjectAsync(id, newMilestone);

            return Ok(addedMilestone);
        }
    }
}
