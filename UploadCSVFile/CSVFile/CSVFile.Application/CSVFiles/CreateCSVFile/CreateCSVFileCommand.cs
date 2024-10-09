using System.Collections.Generic;
using CSVFile.Application.Common.Interfaces;
using CSVFile.Domain.Entities;
using Intent.RoslynWeaver.Attributes;
using MediatR;

 
[assembly: IntentTemplate("Intent.Application.MediatR.CommandModels", Version = "1.0")]

namespace CSVFile.Application.CSVFiles.CreateCSVFile
{
  public class CreateCSVFileCommand : IRequest<ImportResult>, ICommand
  {
    public CreateCSVFileCommand(string fileContents)
    {
      FileContents = fileContents;
    }

    public string FileContents { get; set; }
    public char Delimiter { get; set; } = ','; // Default to comma
  }
}