using FluentValidation;

namespace CardManagement.API.Commands.Account.CreateAccount
{
    public class CreateAccountValidator : AbstractValidator<CreateAccountCommand>
    {
        public CreateAccountValidator()
        {
            RuleFor(x => x.Type).Must(BeAValidType);
        }




        private bool BeAValidType(string type)
        {
            switch (type.ToLower())
            {
                case "deposit":
                    return true;
                case "credit":
                    return true;
                case "currency":
                    return true;
                default:
                    return false;
            }
        }
    }
}