using AutoMapper;
using Lagalt_Backend.Services.Owners;
using Lagalt_Backend.Data.Dtos.Owners;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using Lagalt_Backend.Data.Exceptions;
using Lagalt_Backend.Data.Models.OwnerModels;
using Lagalt_Backend.Data.Dtos.Projects;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Lagalt_Backend.Controllers
{
    [Route("api/v1/owners")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [ApiConventionType(typeof(DefaultApiConventions))]


    public class OwnersController : ControllerBase
    {
        private readonly IOwnerService _ownerService;
        private readonly IMapper _mapper;

        public OwnersController(IOwnerService ownerService, IMapper mapper)
        {
            _ownerService = ownerService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OwnerDTO>>> GetOwners()
        {
            return Ok(_mapper
                .Map<IEnumerable<OwnerDTO>>(
                    await _ownerService.GetAllAsync()));
        }

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

        [HttpPost]
        public async Task<ActionResult<OwnerDTO>> PostOwner(OwnerPostDTO owner)
        {
            var newOwner = await _ownerService.AddAsync(_mapper.Map<Owner>(owner));

            return CreatedAtAction("GetOwner",
                new { id = newOwner.Id },
                _mapper.Map<OwnerDTO>(newOwner));
        }

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
