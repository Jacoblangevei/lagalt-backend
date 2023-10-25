using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using Lagalt_Backend.Services.Messages;
using Lagalt_Backend.Data.Dtos.Messages;
using Lagalt_Backend.Data.Models.MessageModels;
using Lagalt_Backend.Data.Exceptions;
using System.Collections.Generic;
using System.Threading.Tasks;
using Lagalt_Backend.Data.Dtos.Skills;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Cors;

namespace Lagalt_Backend.Controllers
{
    //messages remade


    /// <summary>
    /// Handles API endpoints for operations related to Messages.
    /// </summary>
    [Route("api/v1/messages")]
    [ApiController]
    [Authorize]
    [Produces(MediaTypeNames.Application.Json)]
    [ApiConventionType(typeof(DefaultApiConventions))]
    [EnableCors("MyAllowSpecificOrigins")]
    public class MessagesController : ControllerBase
    {
        private readonly IMessageService _msgService;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="MessagesController"/> class.
        /// </summary>
        /// <param name="msgService">The service for accessing message operations.</param>
        /// <param name="mapper">The mapper for converting entity models to DTOs and vice versa.</param>
        public MessagesController(IMessageService msgService, IMapper mapper)
        {
            _msgService = msgService;
            _mapper = mapper;
        }

        /// <summary>
        /// Gets all replies a message has
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}/replies")]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<Message>>> GetRepliesInMessage(int id)
        {
            var replies = await _msgService.GetRepliesInMessageAsync(id);
            return Ok(replies);
        }

        /// <summary>
        /// Gets reply from message by id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="replyId"></param>
        /// <returns></returns>
        [HttpGet("{id}/replies/{replyId}")]
        [AllowAnonymous]
        public async Task<ActionResult<Message>> GetReplyInMessageById(int id, int replyId)
        {
            var reply = await _msgService.GetReplyInMessageByIdAsync(id, replyId);

            if (reply == null)
            {
                return NotFound();
            }

            return Ok(reply);
        }

        /// <summary>
        /// Adds reply to message
        /// </summary>
        /// <param name="id"></param>
        /// <param name="messagePostDTO"></param>
        /// <returns></returns>
        [HttpPost("{id}/replies")]
        [Authorize]
        public async Task<ActionResult<MessageDTO>> AddReplyToMessage(int id, [FromBody] MessagePostDTO messagePostDTO)
        {
            //string userId = "00000000-0000-0000-0000-000000000001";
            //string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            //Guid userGuid = Guid.Parse(userId);

            var parentMessage = await _msgService.GetByIdAsync(id);

            if (parentMessage == null)
            {
                return NotFound(); 
            }

            var newReply = new Message
            {
                Subject = messagePostDTO.Subject,
                MessageContent = messagePostDTO.MessageContent,
                ImageUrl = messagePostDTO.ImageUrl,
                Timestamp = DateTime.UtcNow,
                UserId = Guid.Parse(userId),
                ParentId = id
            };

            var addedReply = await _msgService.AddAsync(newReply);

            var addedReplyDTO = _mapper.Map<MessageDTO>(addedReply);

            return Ok(addedReplyDTO);
        }
    }
}
