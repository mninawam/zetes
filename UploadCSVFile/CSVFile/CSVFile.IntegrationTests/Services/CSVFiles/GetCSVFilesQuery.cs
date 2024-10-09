using Intent.RoslynWeaver.Attributes;

 
[assembly: DefaultIntentManaged(Mode.Fully, Targets = Targets.Usings)]
[assembly: IntentTemplate("Intent.AspNetCore.IntegrationTesting.DtoContract", Version = "2.0")]

namespace CSVFile.IntegrationTests.Services.CSVFiles
{
    public class GetCSVFilesQuery
    {
        public static GetCSVFilesQuery Create()
        {
            return new GetCSVFilesQuery
            {
            };
        }
    }
}