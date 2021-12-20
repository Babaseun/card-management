using CardManagement.Data.EntityConfigurations;
using FluentValidation;

namespace CardManagement.API.Commands.User.SignInUser
{
    public class SigninUserCommandValidator : AbstractValidator<SignInUserCommand>
    {
        public SigninUserCommandValidator()
        {
            RuleFor(u => u.Email).EmailAddress()
                                 .Matches(@"^([\w+-.%]+@[\w-.]+\.[A-Za-z]{2,4};?)+$")
                                 .WithMessage("Email address is not valid.")
                                 .MaximumLength(Restrictions.User.EmailLength);

            RuleFor(c => c.Password).NotEmpty();
        }
    }
}