using System.Collections.Generic;
using CSVFile.Application.Common.Interfaces;
using Intent.RoslynWeaver.Attributes;
using MediatR;

 
[assembly: IntentTemplate("Intent.Application.MediatR.QueryModels", Version = "1.0")]

namespace CSVFile.Application.CSVFiles.GetCSVFiles
{
    public class GetCSVFilesQuery : IRequest<List<FieldDto>>, IQuery
    {
        public GetCSVFilesQuery()
        {
        }
    }
}