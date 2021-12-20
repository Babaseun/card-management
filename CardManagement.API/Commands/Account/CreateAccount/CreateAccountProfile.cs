using AutoMapper;
using CardManagement.API.Commands.Dtos;

namespace CardManagement.API.Commands.Account.CreateAccount
{
    public class CreateAccountProfile : Profile
    {
        public CreateAccountProfile()
        {
            CreateMap<Domain.Entities.Account, AccountDetailsDto>();
                
        }
    }
}