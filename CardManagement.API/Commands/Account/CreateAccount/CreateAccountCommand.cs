using CardManagement.API.Commands.Dtos;
using MediatR;

namespace CardManagement.API.Commands.Account.CreateAccount
{
	public class CreateAccountCommand :  IRequest<AccountDetailsDto>
    {
        public string Type { get; set; }
        
    }
}