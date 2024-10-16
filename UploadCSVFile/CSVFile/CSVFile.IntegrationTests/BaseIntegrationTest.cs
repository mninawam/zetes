using Intent.RoslynWeaver.Attributes;
using Microsoft.Extensions.DependencyInjection;

 
[assembly: IntentTemplate("Intent.AspNetCore.IntegrationTesting.BaseIntegrationTest", Version = "1.0")]

namespace CSVFile.IntegrationTests
{
    public class BaseIntegrationTest
    {
        public BaseIntegrationTest(IntegrationTestWebAppFactory webAppFactory)
        {
            WebAppFactory = webAppFactory;
        }

        public IntegrationTestWebAppFactory WebAppFactory { get; }

        protected HttpClient CreateClient()
        {
            return WebAppFactory.CreateClient();
        }
    }
}