using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CSVFile.Domain.Repositories;
using Intent.RoslynWeaver.Attributes;
using MediatR;

 
[assembly: IntentTemplate("Intent.Application.MediatR.QueryHandler", Version = "1.0")]

namespace CSVFile.Application.CSVFiles.GetCSVFiles
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class GetCSVFilesQueryHandler : IRequestHandler<GetCSVFilesQuery, List<FieldDto>>
    {
        private readonly ICSVFileRepository _cSVFileRepository;

        [IntentManaged(Mode.Merge)]
        public GetCSVFilesQueryHandler(ICSVFileRepository cSVFileRepository)
        {
            _cSVFileRepository = cSVFileRepository;
        }

        [IntentManaged(Mode.Fully, Body = Mode.Fully)]
        public async Task<List<FieldDto>> Handle(GetCSVFilesQuery request, CancellationToken cancellationToken)
        {
            var cSVFiles = await _cSVFileRepository.FindAllAsync(cancellationToken);

            // TODO: Implement return type mapping...
            throw new NotImplementedException("Implement return type mapping...");
        }
    }
}