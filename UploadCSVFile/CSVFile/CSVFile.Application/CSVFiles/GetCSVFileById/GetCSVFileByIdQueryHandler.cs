using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CSVFile.Domain.Common.Exceptions;
using CSVFile.Domain.Repositories;
using Intent.RoslynWeaver.Attributes;
using MediatR;


[assembly: IntentTemplate("Intent.Application.MediatR.QueryHandler", Version = "1.0")]

namespace CSVFile.Application.CSVFiles.GetCSVFileById
{

  public class GetCSVFileByIdQueryHandler : IRequestHandler<GetCSVFileByIdQuery, CSVFileDto>
  {
    private readonly ICSVFileRepository _cSVFileRepository;
    private readonly IMapper _mapper;


    public GetCSVFileByIdQueryHandler(ICSVFileRepository cSVFileRepository, IMapper mapper)
    {
      _cSVFileRepository = cSVFileRepository;
      _mapper = mapper;
    }


    public async Task<CSVFileDto> Handle(GetCSVFileByIdQuery request, CancellationToken cancellationToken)
    {
      throw new NotFoundException($"Could not find CSVFile '{request.FileContents}'");
    }
  }
}