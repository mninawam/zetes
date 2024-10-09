using FluentValidation;
using Intent.RoslynWeaver.Attributes;

 
[assembly: IntentTemplate("Intent.Application.MediatR.FluentValidation.QueryValidator", Version = "2.0")]

namespace CSVFile.Application.CSVFiles.GetCSVFiles
{
    [IntentManaged(Mode.Fully, Body = Mode.Merge)]
    public class GetCSVFilesQueryValidator : AbstractValidator<GetCSVFilesQuery>
    {
        [IntentManaged(Mode.Merge)]
        public GetCSVFilesQueryValidator()
        {
            ConfigureValidationRules();
        }

        private void ConfigureValidationRules()
        {
        }
    }
}