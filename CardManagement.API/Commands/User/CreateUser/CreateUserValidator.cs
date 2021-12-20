using CardManagement.Data.EntityConfigurations;
using FluentValidation;

namespace CardManagement.API.Commands.User.CreateUser
{
    public class CreateUserValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserValidator()
        {
            RuleFor(u => u.Email).NotEmpty()
                                 .EmailAddress()
                                 .Matches(@"^([\w+-.%]+@[\w-.]+\.[A-Za-z]{2,4};?)+$")
                                 .WithMessage("Email address is not valid.")
                                 .MaximumLength(Restrictions.User.EmailLength);

            RuleFor(u => u.Password).NotEmpty().Matches(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$")
                                    .WithMessage(
                                        "Password requires minimum eight characters, at least one letter and one number");

            RuleFor(u => u.Firstname).NotEmpty().MaximumLength(Restrictions.User.FirstNameLength);
            RuleFor(u => u.Lastname).NotEmpty().MinimumLength(5).MaximumLength(Restrictions.User.LastNameLength);
        }
    }
}