using CSVFile.IntegrationTests.Services.CSVFiles;
using Intent.RoslynWeaver.Attributes;

 
[assembly: DefaultIntentManaged(Mode.Fully, Targets = Targets.Usings)]
[assembly: IntentTemplate("Intent.AspNetCore.IntegrationTesting.ProxyServiceContract", Version = "1.0")]

namespace CSVFile.IntegrationTests.HttpClients.CSVFiles
{
    public interface ICSVFilesService : IDisposable
    {
        Task<List<FieldDto>> CreateCSVFileAsync(CreateCSVFileCommand command, CancellationToken cancellationToken = default);
        Task<CSVFileDto> GetCSVFileByIdAsync(string fileContents, CancellationToken cancellationToken = default);
        Task<List<FieldDto>> GetCSVFilesAsync(CancellationToken cancellationToken = default);
    }
}