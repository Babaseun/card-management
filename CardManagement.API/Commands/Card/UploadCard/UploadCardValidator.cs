using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace CardManagement.API.Commands.Card.UploadCard
{
    public class UploadCardValidator : AbstractValidator<UploadCardCommand>
    {
        public UploadCardValidator()
        {
             RuleFor(f => f.File)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("File not uploaded")
                .Must(BeACsvFile).WithMessage("Only csv file is allowed to be uploaded");
        }
        private static bool BeACsvFile(IFormFile file)
        {
            var extension = System.IO.Path.GetExtension(file.FileName);
            return extension == ".xlsx";
        }
    }
}