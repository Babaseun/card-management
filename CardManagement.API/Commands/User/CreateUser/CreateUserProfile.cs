using AutoMapper;
using CardManagement.API.Commands.Dtos;


namespace CardManagement.API.Commands.User.CreateUser
{
    public class CreateUserProfile : Profile
    {
        public CreateUserProfile()
        {
            CreateMap<CreateUserCommand, Domain.Entities.User>()
                .ForMember(d => d.Firstname, opt => opt.MapFrom(s => s.Firstname))
                .ForMember(d => d.Lastname, opt => opt.MapFrom(s => s.Lastname))
                .ForMember(d => d.NormalizedEmail, opt => opt.MapFrom(s => s.Email))
                .ForMember(d => d.NormalizedUserName, opt => opt.MapFrom(s => s.Email))
                .ForMember(d => d.NormalizedUserName, opt => opt.MapFrom(s => s.Email))
                .ForMember(d => d.UserName, opt => opt.MapFrom(s => s.Email));

            CreateMap<Domain.Entities.User, UserDetailsDto>();
        }
    }
}