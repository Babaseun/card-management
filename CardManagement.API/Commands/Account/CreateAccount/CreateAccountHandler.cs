using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CardManagement.API.Commands.Dtos;
using CardManagement.Domain.Services;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace CardManagement.API.Commands.Account.CreateAccount
{
    public class CreateAccountHandler : IRequestHandler<CreateAccountCommand, AccountDetailsDto>
    {
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CreateAccountHandler(IAccountService accountService, IMapper mapper,   IHttpContextAccessor httpContextAccessor)
        {
            _accountService = accountService;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<AccountDetailsDto> Handle(CreateAccountCommand command, CancellationToken cancellationToken)
        {
            var userId =  _httpContextAccessor.HttpContext?.User.Claims.FirstOrDefault(claim => claim.Type == "Id")?.Value;

            var account = new Domain.Entities.Account()
            {
                Type = command.Type,
                UserId = userId
            };
            await _accountService.CreateAccount(account);
            var result = _mapper.Map<AccountDetailsDto>(account);
            return result;
        }
    }
}