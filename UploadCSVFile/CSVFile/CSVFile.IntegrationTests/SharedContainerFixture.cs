using Intent.RoslynWeaver.Attributes;

 
[assembly: IntentTemplate("Intent.AspNetCore.IntegrationTesting.SharedContainerFixture", Version = "1.0")]

namespace CSVFile.IntegrationTests
{
    [CollectionDefinition("SharedContainer")]
    public class SharedContainerFixture : ICollectionFixture<IntegrationTestWebAppFactory>
    {
    }
}