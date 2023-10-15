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

        //Get all messages


        //Get message by id

        //Add message to project

        //Delete message from project

        //Get all comments from message

        //Get comment in project by id

        //Add comment to message

        //Delete comment from message

    }
}
