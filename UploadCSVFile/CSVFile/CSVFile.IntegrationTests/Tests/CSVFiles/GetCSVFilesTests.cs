using Intent.RoslynWeaver.Attributes;

 
[assembly: IntentTemplate("Intent.AspNetCore.IntegrationTesting.ServiceEndpointTest", Version = "1.0")]

namespace CSVFile.IntegrationTests.Tests
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    [Collection("SharedContainer")]
    public class GetCSVFilesTests : BaseIntegrationTest
    {
        public GetCSVFilesTests(IntegrationTestWebAppFactory factory) : base(factory)
        {
        }
    }
}