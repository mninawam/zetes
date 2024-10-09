using Intent.RoslynWeaver.Attributes;

 
[assembly: DefaultIntentManaged(Mode.Fully, Targets = Targets.Usings)]
[assembly: IntentTemplate("Intent.AspNetCore.IntegrationTesting.DtoContract", Version = "2.0")]

namespace CSVFile.IntegrationTests.Services.CSVFiles
{
    public class GetCSVFileByIdQuery
    {
        public GetCSVFileByIdQuery()
        {
            FileContents = null!;
        }

        public string FileContents { get; set; }

        public static GetCSVFileByIdQuery Create(string fileContents)
        {
            return new GetCSVFileByIdQuery
            {
                FileContents = fileContents
            };
        }
    }
}