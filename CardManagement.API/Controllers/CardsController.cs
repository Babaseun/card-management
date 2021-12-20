using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CardManagement.API.Commands.Card.UploadCard;
using CardManagement.API.Commands.User.ChangePassword;
using CardManagement.API.Commands.User.CreateUser;
using CardManagement.API.Commands.User.SignInUser;
using CardManagement.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CardManagement.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CardsController : ControllerBase
    {
        private readonly ILogger<CardsController> _logger;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;


        public CardsController(ILogger<CardsController> logger,
                               IMapper mapper, IMediator mediator)
        {
            _logger = logger;
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadCards([FromForm]  UploadCardCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
       
    }
}