using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using CardManagement.API.Exceptions;
using CardManagement.Domain.Helper;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace CardManagement.API.Commands.User.SignInUser
{
    public class SignInUserHandler: IRequestHandler<SignInUserCommand, string>
    {
        private readonly SignInManager<Domain.Entities.User> _signInManager;
        private readonly UserManager<Domain.Entities.User> _userManager;
        private readonly Helper _helper;

        public SignInUserHandler(SignInManager<Domain.Entities.User> signInManager, UserManager<Domain.Entities.User> userManager, Helper helper)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _helper = helper;
        }
        public async Task<string> Handle(SignInUserCommand command, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(command.Email);

            if (user is null)
            {
                throw new UserNotFoundException(command.Email);
            }
            var signInResult = await _signInManager.PasswordSignInAsync(command.Email, command.Password, false, false);

            if (signInResult.Succeeded)
            {
                var userRoles = await _userManager.GetRolesAsync(user);

                var authClaims = userRoles.Select(userRole => new Claim(ClaimTypes.Role, userRole)).ToList();

                authClaims.Add(new Claim("Id", user.Id));
                
                var token = _helper.GenerateToken(authClaims);

                return token;
            }
            else
            {
                throw new BadRequestException("User not logged in");
            }
        }
    }
}