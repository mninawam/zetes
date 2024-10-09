using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CSVFile.Domain.Entities;
using CSVFile.Domain.Repositories;
using MediatR;
using System.IO;
using System.Linq;

namespace CSVFile.Application.CSVFiles.CreateCSVFile
{
  public class CreateCSVFileCommandHandler : IRequestHandler<CreateCSVFileCommand, ImportResult>
  {
    private readonly ICSVFileRepository _cSVFileRepository;

    public CreateCSVFileCommandHandler(ICSVFileRepository cSVFileRepository)
    {
      _cSVFileRepository = cSVFileRepository;
    }

    public async Task<ImportResult> Handle(CreateCSVFileCommand request, CancellationToken cancellationToken)
    {

      ImportResult importResult = new ImportResult();
      // Decode the base64 string to get the CSV content
      var csvContent = Encoding.UTF8.GetString(Convert.FromBase64String(request.FileContents));

      var handler = new CreateCSVFileCommandValidationHandler();
      try
      {
        handler.ValidateCsv(csvContent);
        Console.WriteLine("CSV file is valid.");
      }
      catch (CSVFileErrorException ex)
      {
        foreach (var error in ex.Errors)
        {
          importResult.Errors.Add(error);
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine("Failed to import the file. Please refer to the \"Import best practices\" article when creating the CSV and import it again.");
      }

      if(importResult.Errors.Any())
      {
        return importResult;
      }
      // Parse the CSV content with the specified delimiter
      var fields = ParseCsv(csvContent, request.Delimiter);

      // Create a CSVFile entity and populate it with the parsed data
      var cSVFile = new Domain.Entities.CSVFile
      {
        Fields = fields
      };

      // Save the CSVFile entity along with its fields to the database
      //_cSVFileRepository.Add(cSVFile);
      //await _cSVFileRepository.SaveChangesAsync(cancellationToken);

      importResult.FieldData = fields;

      return importResult;
    }

    #region Private Methods

    private List<CSVField> ParseCsv(string csvContent, char delimiter)
    {
      var fields = new List<Field>();
      var csvRecords = new List<CSVField>();


      using (var reader = new StringReader(csvContent))
      {
        string headerLine = reader.ReadLine();
        if (headerLine == null)
        {
          throw new InvalidOperationException("CSV file is empty.");
        }

        var headers = headerLine.Split(delimiter);

        string line;
        while ((line = reader.ReadLine()) != null)
        {
          var values = line.Split(delimiter);
          var field = new Field();
          
          for (int i = 0; i < headers.Length; i++)
          {
            // Ensure unique keys within the context of a single Field
            if (!field.Data.Any(fd => fd.Key == headers[i]))
            {
              field.Data.Add(new FieldData
              {
                Key = headers[i],
                Value = values.Length > i ? values[i] : null
              });
            }
          }

          fields.Add(field);
          csvRecords.Add(new CSVField() {  FieldData = field });
        }
      }
      return csvRecords;
    }

    #endregion
  }
}