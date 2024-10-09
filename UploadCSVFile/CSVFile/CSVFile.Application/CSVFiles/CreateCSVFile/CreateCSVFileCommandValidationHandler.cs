using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVFile.Application.CSVFiles.CreateCSVFile
{
  public class CreateCSVFileCommandValidationHandler
  {

    private static readonly string[] RequiredHeaders = { "Name", "Type", "Search", "Library Filter", "Visible" };
    private static readonly string[] ValidFieldTypes = { "Text", "Number", "Yes/No", "Date", "Image" };
    private static readonly string[] YesNoValues = { "yes", "no" };

    public void ValidateCsv(string csvContent)
    {
      var errors = new List<string>();

      using (var reader = new StringReader(csvContent))
      {

        string headerLine = reader.ReadLine();
        if (headerLine == null)
        {
          errors.Add("The CSV is empty. Please populate the CSV and import it again. Please refer to the \"Import best practices\" article when creating the CSV.");
        }

        var headers = headerLine.Split(',');
        ValidateHeaders(headers, errors);

        string line;
        int lineNumber = 0;
        while ((line = reader.ReadLine()) != null)
        {
          var fields = line.Split(',');

          if (fields.Length < 5)
          {
            errors.Add("The file you have imported cannot be recognized. Please import a CSV file format.");
          }

          ValidateFieldValues(fields, lineNumber + 1, errors);
          ValidateFieldLengths(fields, errors);
          ValidateFieldTypes(fields, lineNumber + 1, errors);
          ValidateFieldTypeProperties(fields, lineNumber + 1, errors);
          lineNumber++;
        }

        // Reinitialize the StringReader to read from the start again
        using (var newReader = new StringReader(csvContent))
        {
          // Read all lines in reader
          string lines = newReader.ReadToEnd();
          // Convert to array of lines
          var convertedLines = lines.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

          ValidateAtLeastOneSearchableTextField(convertedLines, errors);
          ValidateAtLeastOneDateField(convertedLines, errors);
        }

      }

      if (errors.Any())
      {
        throw new CSVFileErrorException(errors);
      }

    }

    private void ValidateHeaders(string[] headers, List<string> errors)
    {
      // Remove hidden characters and trim whitespace
      var cleanedHeaders = headers.Select(h => h.Trim().ToLower().Replace("\uFEFF", "")).ToArray();
      var requiredHeadersLower = RequiredHeaders.Select(h => h.ToLower()).ToArray();

      foreach (var requiredHeader in requiredHeadersLower)
      {
        if (!cleanedHeaders.Contains(requiredHeader))
        {
          errors.Add("The header in the file you have imported cannot be recognized. Please include the following headers: Name, Type, Search, Library filter and Visible.");
        }
      }
    }

    private void ValidateFieldValues(string[] fields, int rowIndex, List<string> errors)
    {
      for (int i = 0; i < RequiredHeaders.Length; i++)
      {
        if (string.IsNullOrWhiteSpace(fields[i]))
        {
          errors.Add($"Line {rowIndex}: The value in the '{RequiredHeaders[i]}' column on is empty. Update the CSV and try to import again.");
        }
      }
    }

    private void ValidateFieldLengths(string[] fields, List<string> errors)
    {
      foreach (var field in fields)
      {
        if (field.Length > 100)
        {
          errors.Add("The field name cannot exceed 100 characters.");
        }
      }
    }

    private void ValidateFieldTypes(string[] fields, int rowIndex, List<string> errors)
    {
      var type = fields[1];
      if (!ValidFieldTypes.Contains(type))
      {
        errors.Add($"Line {rowIndex}: The value in the 'Type' column  is invalid. Update it to Text, Number, Yes/No, Date or Image and try to import again.");
      }
    }

    private void ValidateFieldTypeProperties(string[] fields, int rowIndex, List<string> errors)
    {
      var type = fields[1];
      var search = fields[2].ToLower();
      var filter = fields[3].ToLower();
      var visible = fields[4].ToLower();

      if (!YesNoValues.Contains(search))
      {
        errors.Add($"Line {rowIndex}: The value in the 'Search' column is invalid. Update it to Yes or No and try to import again.");
      }

      if (!YesNoValues.Contains(filter))
      {
        errors.Add($"Line {rowIndex}: The value in the 'Library filter' column is invalid. Update it to Yes or No and try to import again.");
      }

      if (!YesNoValues.Contains(visible))
      {
        errors.Add($"Line {rowIndex}: The value in the 'Visible' column on is invalid. Update it to Yes or No and try to import again.");
      }

      if (type == "Text" && (search != "yes" || filter != "yes" || visible != "yes"))
      {
        errors.Add($"Line {rowIndex}: The value in the 'Search' column is invalid. A Text field must be searchable, filterable, and visible.");
      }

      if ((type == "Number" || type == "Date" || type == "Image") && (search == "yes" || filter == "yes"))
      {
        errors.Add($"Line {rowIndex}: The value in the 'Search' or 'Library filter' column is invalid. A {type} field cannot be searchable or filterable.");
      }

      if (type == "Yes/No" && search == "yes")
      {
        errors.Add($"Line {rowIndex}: The value in the 'Search' column is invalid. A Yes/No field cannot be searchable.");
      }
    }

    private void ValidateAtLeastOneSearchableTextField(string[] lines, List<string> errors)
    {
      var hasSearchableTextField = lines.Any(line => line.Split(',')[1] == "Text" && line.Split(',')[2].ToLower() == "yes");

      foreach (var line in lines)
      {
        var fields = line.Split('\n');
        foreach (var field in fields)
        {
          if (field.ToLower().Replace("\uFEFF", "").Contains("text") && field.ToLower().Replace("\uFEFF", "").Contains("yes"))
          {
            hasSearchableTextField = true;
            break;
          }
        }

      }

      if (!hasSearchableTextField)
      {
        errors.Add("At least one field must be marked as searchable.");
      }
    }

    private void ValidateAtLeastOneDateField(string[] lines, List<string> errors)
    {

      var hasDateField = lines.Any(line => line.Split(',')[1].ToLower().Replace("\uFEFF", "").Contains("date"));

      foreach(var line in lines)
      {
        var fields = line.Split('\n');
        foreach (var field in fields)
        {
          if (field.ToLower().Replace("\uFEFF", "").Contains("date"))
          {
            hasDateField = true;
            break;
          }
        }

      }
      if (!hasDateField)
      {
        errors.Add("At least one field must be of type Date.");
      }
    }

  }
}
