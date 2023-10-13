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

namespace Lagalt_Backend.Controllers
{
    //messages remade


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

        //Get all messages

        //Get message by id

        //Create message

    }
}
