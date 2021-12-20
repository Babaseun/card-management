using MediatR;

namespace CardManagement.API.Commands.User.SignInUser

{
    public class SignInUserCommand : IRequest<string>
    {
         public string Email { get; set; }
         public string Password { get; set; }
    }
}