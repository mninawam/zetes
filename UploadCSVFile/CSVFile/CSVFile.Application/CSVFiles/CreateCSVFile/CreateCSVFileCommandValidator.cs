using FluentValidation;
using Intent.RoslynWeaver.Attributes;

 
[assembly: IntentTemplate("Intent.Application.MediatR.FluentValidation.CommandValidator", Version = "2.0")]

namespace CSVFile.Application.CSVFiles.CreateCSVFile
{
    [IntentManaged(Mode.Fully, Body = Mode.Merge)]
    public class CreateCSVFileCommandValidator : AbstractValidator<CreateCSVFileCommand>
    {
        [IntentManaged(Mode.Merge)]
        public CreateCSVFileCommandValidator()
        {
            ConfigureValidationRules();
        }

        private void ConfigureValidationRules()
        {
            RuleFor(v => v.FileContents)
                .NotNull();
        }
    }
}