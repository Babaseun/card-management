using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
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
    [Route("api/v1/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;


        public UsersController(ILogger<UsersController> logger,
                               IMapper mapper, IMediator mediator)
        {
            _logger = logger;
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpPost("signup")]
        public async Task<IActionResult> Signup(CreateUserCommand command)
        {
            var response = await _mediator.Send(command);

            return Ok(response);
        }
        [HttpPost("signin")]
        public async Task<IActionResult> Signin(SignInUserCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
        [HttpPost("change-password")]
        public async Task<IActionResult> ChangePassword(ChangePasswordCommand command)
        { var response = await _mediator.Send(command);
            return NoContent();
        }
    }
}