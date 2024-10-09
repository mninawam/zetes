using Intent.RoslynWeaver.Attributes;

 
[assembly: DefaultIntentManaged(Mode.Fully, Targets = Targets.Usings)]
[assembly: IntentTemplate("Intent.AspNetCore.IntegrationTesting.DtoContract", Version = "2.0")]

namespace CSVFile.IntegrationTests.Services.CSVFiles
{
    public class CSVFileDto
    {
        public CSVFileDto()
        {
            FileContents = null!;
        }

        public string FileContents { get; set; }

        public static CSVFileDto Create(string fileContents)
        {
            return new CSVFileDto
            {
                FileContents = fileContents
            };
        }
    }
}