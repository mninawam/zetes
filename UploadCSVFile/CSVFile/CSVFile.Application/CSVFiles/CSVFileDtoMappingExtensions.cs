using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using CSVFile.Domain.Entities;
using Intent.RoslynWeaver.Attributes;

 
[assembly: IntentTemplate("Intent.Application.Dtos.AutoMapper.MappingExtensions", Version = "1.0")]

namespace CSVFile.Application.CSVFiles
{
    public static class CSVFileDtoMappingExtensions
    {
        public static CSVFileDto MapToCSVFileDto(this Domain.Entities.CSVFile projectFrom, IMapper mapper)
            => mapper.Map<CSVFileDto>(projectFrom);

        public static List<CSVFileDto> MapToCSVFileDtoList(this IEnumerable<Domain.Entities.CSVFile> projectFrom, IMapper mapper)
            => projectFrom.Select(x => x.MapToCSVFileDto(mapper)).ToList();
    }
}