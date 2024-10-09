using CSVFile.Application.Common.Interfaces;
using Intent.RoslynWeaver.Attributes;
using MediatR;

 
[assembly: IntentTemplate("Intent.Application.MediatR.QueryModels", Version = "1.0")]

namespace CSVFile.Application.CSVFiles.GetCSVFileById
{
    public class GetCSVFileByIdQuery : IRequest<CSVFileDto>, IQuery
    {
        public GetCSVFileByIdQuery(string fileContents)
        {
            FileContents = fileContents;
        }

        public string FileContents { get; set; }
    }
}