using AutoMapper;
using CSVFile.Application.Common.Mappings;
using CSVFile.Domain.Entities;
using Intent.RoslynWeaver.Attributes;

 
[assembly: IntentTemplate("Intent.Application.Dtos.DtoModel", Version = "1.0")]

namespace CSVFile.Application.CSVFiles
{
    public class CSVFileDto : IMapFrom<Domain.Entities.CSVFile>
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

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entities.CSVFile, CSVFileDto>();
        }
    }
}