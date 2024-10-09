using FluentValidation;
using Intent.RoslynWeaver.Attributes;

 
[assembly: IntentTemplate("Intent.Application.MediatR.FluentValidation.QueryValidator", Version = "2.0")]

namespace CSVFile.Application.CSVFiles.GetCSVFileById
{
    [IntentManaged(Mode.Fully, Body = Mode.Merge)]
    public class GetCSVFileByIdQueryValidator : AbstractValidator<GetCSVFileByIdQuery>
    {
        [IntentManaged(Mode.Merge)]
        public GetCSVFileByIdQueryValidator()
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