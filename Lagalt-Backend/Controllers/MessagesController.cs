﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using Lagalt_Backend.Services.Messages;
using Lagalt_Backend.Data.Dtos.Messages;
using Lagalt_Backend.Data.Dtos.Comments;
using Lagalt_Backend.Data.Models.MessageModels;
using Lagalt_Backend.Data.Exceptions;
using System.Collections.Generic;
using System.Threading.Tasks;
using Lagalt_Backend.Data.Dtos.Skills;

namespace Lagalt_Backend.Controllers
{
    /// <summary>
    /// Handles API endpoints for operations related to Messages.
    /// </summary>
    [Route("api/v1/messages")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [ApiConventionType(typeof(DefaultApiConventions))]
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
        /// Gets all comments in a specific message.
        /// </summary>
        /// <param name="id">The ID of the message.</param>
        /// <returns>An ActionResult of type IEnumerable of CommentDTOs.</returns>
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

        [HttpGet("{id}/comments/{commentId}")]
        public async Task<ActionResult<CommentDTO>> GetCommentInMessageById(int id, int commentId)
        {
            try
            {
                var comment = await _msgService.GetCommentInMessageByIdAsync(id, commentId);
                return Ok(_mapper.Map<CommentDTO>(comment));
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost("{id}/comments")]
        public async Task<ActionResult<CommentDTO>> AddCommentToMessage(int messageId, [FromBody] CommentPostDTO commentDto)
        {
            try
            {
                var creatorId = 1; // Needs to be replaced when keycloak is set up 
                var creatorRole = "user"; // Needs to be replaced when keycloak is set up

                Comment newComment = await _msgService.AddNewCommentToMessageAsync(messageId, commentDto.CommentText, creatorId, creatorRole);

                return CreatedAtAction("GetCommentInMessageById", new { id = messageId, commentId = newComment.CommentId }, _mapper.Map<CommentDTO>(newComment));
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
