using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using Lagalt_Backend.Services.Messages;
using Lagalt_Backend.Data.Dtos.Messages;
using Lagalt_Backend.Data.Dtos.Comments;
using Lagalt_Backend.Data.Models.MessageModels;
using Lagalt_Backend.Data.Exceptions;


namespace Lagalt_Backend.Controllers
{
    [Route("api/v1/messages")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class MessagesController : ControllerBase
    {
        private readonly IMessageService _msgService;
        private readonly IMapper _mapper;

        public MessagesController(IMessageService msgService, IMapper mapper)
        {
            _msgService = msgService;
            _mapper = mapper;
        }

        [HttpGet("{id}/comments")]
        public async Task<ActionResult<IEnumerable<CommentDTO>>> GetAllCommentsInMessage(int id)
        {
            try
            {
                return Ok(_mapper
                    .Map<IEnumerable<CommentDTO>>(
                        await _msgService.GetAllCommentsInMessageAsync(id)));
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
