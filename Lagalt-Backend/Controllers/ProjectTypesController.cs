using AutoMapper;
using Lagalt_Backend.Data.Dtos.ProjectTypes;
using Lagalt_Backend.Data.Dtos.Projects;
using Lagalt_Backend.Data.Exceptions;
using Lagalt_Backend.Services.Projects;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Lagalt_Backend.Controllers
{
    [Route("api/v1/projecttypes")]
    [ApiController]
    [Authorize]
    [Produces(MediaTypeNames.Application.Json)]
    [ApiConventionType(typeof(DefaultApiConventions))]
    [EnableCors("MyAllowSpecificOrigins")]
    public class ProjectTypesController : ControllerBase
    {
        private readonly IProjectTypeService _projecttypeService;
        private readonly IMapper _mapper;

        public ProjectTypesController(IProjectTypeService projecttypeService, IMapper mapper)
        {
            _projecttypeService = projecttypeService;
            _mapper = mapper;
        }

        /// <summary>
        /// Gets all project types
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<ProjectTypeDTO>>> GetProjectTypes()
        {
            return Ok(_mapper
                .Map<IEnumerable<ProjectTypeDTO>>(
                    await _projecttypeService.GetAllAsync()));
        }

        /// <summary>
        /// Gets spesific product type using id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<ProjectTypeDTO>> GetProjectType(int id)
        {
            try
            {
                return Ok(_mapper
                    .Map<ProjectTypeDTO>(
                        await _projecttypeService.GetByIdAsync(id)));
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        //Projects

        /// <summary>
        /// Gets all projects with project type
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}/projects")]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<ProjectDTO>>> GetProjects(int id)
        {
            try
            {
                return Ok(_mapper
                    .Map<IEnumerable<ProjectDTO>>(
                        await _projecttypeService.GetProjectsAsync(id)));
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
