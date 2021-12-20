using FluentValidation;

namespace CardManagement.API.Commands.User.ChangePassword
{
    public class ChangePasswordCommandValidator : AbstractValidator<ChangePasswordCommand>
    {
        public ChangePasswordCommandValidator()
        {
            RuleFor(c => c.CurrentPassword).NotEmpty();

            RuleFor(c => c.NewPassword)
                .NotEmpty()
                .NotEqual(c => c.CurrentPassword);

            RuleFor(c => c.ConfirmNewPassword).Cascade(CascadeMode.Stop)
                                              .NotEmpty()
                                              .Equal(c => c.NewPassword);
        }
    }
}