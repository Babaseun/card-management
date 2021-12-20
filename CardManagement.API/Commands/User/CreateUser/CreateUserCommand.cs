using CardManagement.API.Commands.Dtos;
using MediatR;

namespace CardManagement.API.Commands.User.CreateUser
{
    public class CreateUserCommand : IRequest<UserDetailsDto>
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}