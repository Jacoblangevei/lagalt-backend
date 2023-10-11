using AutoMapper;
using Lagalt_Backend.Services.Owners;
using Lagalt_Backend.Data.Dtos.Owners;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using Lagalt_Backend.Data.Exceptions;
using Lagalt_Backend.Data.Models.OwnerModels;
using Lagalt_Backend.Data.Dtos.Projects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lagalt_Backend.Controllers
{
    /// <summary>
    /// API Controller for operations related to Owners.
    /// </summary>
    [Route("api/v1/owners")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class OwnersController : ControllerBase
    {
        private readonly IOwnerService _ownerService;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="OwnersController"/> class.
        /// </summary>
        /// <param name="ownerService">The service object for accessing owner operations.</param>
        /// <param name="mapper">The AutoMapper object for converting entity models to DTOs and vice versa.</param>
        public OwnersController(IOwnerService ownerService, IMapper mapper)
        {
            _ownerService = ownerService;
            _mapper = mapper;
        }

        /// <summary>
        /// Gets all owners.
        /// </summary>
        /// <returns>A list of owners.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OwnerDTO>>> GetOwners()
        {
            return Ok(_mapper
                .Map<IEnumerable<OwnerDTO>>(
                    await _ownerService.GetAllAsync()));
        }

        /// <summary>
        /// Gets an owner by ID.
        /// </summary>
        /// <param name="id">The ID of the owner.</param>
        /// <returns>The owner DTO if found.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<OwnerDTO>> GetOwner(int id)
        {
            try
            {
                return Ok(_mapper
                    .Map<OwnerDTO>(
                        await _ownerService.GetByIdAsync(id)));
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        /// <summary>
        /// Creates a new owner.
        /// </summary>
        /// <param name="owner">The new owner's data.</param>
        /// <returns>A newly created owner.</returns>
        [HttpPost]
        public async Task<ActionResult<OwnerDTO>> PostOwner(OwnerPostDTO owner)
        {
            var newOwner = await _ownerService.AddAsync(_mapper.Map<Owner>(owner));

            return CreatedAtAction("GetOwner",
                new { id = newOwner.Id },
                _mapper.Map<OwnerDTO>(newOwner));
        }

        /// <summary>
        /// Deletes an owner by ID.
        /// </summary>
        /// <param name="id">The ID of the owner to delete.</param>
        /// <returns>An IActionResult object.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProject(int id)
        {
            try
            {
                await _ownerService.DeleteByIdAsync(id);
                return NoContent();
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        /// <summary>
        /// Gets all projects owned by a specific owner.
        /// </summary>
        /// <param name="id">The ID of the owner.</param>
        /// <returns>A list of projects the specified owner owns.</returns>
        [HttpGet("{id}/projects")]
        public async Task<ActionResult<IEnumerable<ProjectDTO>>> GetAllProjectsOwnerOwns(int id)
        {
            try
            {
                return Ok(_mapper
                    .Map<IEnumerable<ProjectDTO>>(
                        await _ownerService.GetAllProjectsOwnerOwnsAsync(id)));
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
