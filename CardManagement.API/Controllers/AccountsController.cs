using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CardManagement.API.Commands.Account.CreateAccount;
using CardManagement.API.Queries.Account;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CardManagement.API.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Authorize(Roles = "Admin, User")]
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AccountsController : ControllerBase
    {
        private readonly ILogger<AccountsController> _logger;
        private readonly AccountQueries _accountQueries;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public AccountsController(ILogger<AccountsController> logger,
                                  IMapper mapper,AccountQueries accountQueries, IMediator mediator)
        {
            _logger = logger;
            _accountQueries = accountQueries;
            _mediator = mediator;
        }

        [HttpGet("{userId}/{perPage}/{pageNumber}")]
        public async Task<IActionResult> GetAccountsByUserId(string userId, int perPage, int pageNumber)
            => Ok(await _accountQueries.GetAccountsByUserId(userId, perPage, pageNumber));

        [HttpPost]
        public async Task<IActionResult> CreateAccount(CreateAccountCommand command)
            => Ok(await _mediator.Send(command));
    }
}