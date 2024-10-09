using Intent.RoslynWeaver.Attributes;

 
[assembly: IntentTemplate("Intent.Application.Dtos.DtoModel", Version = "1.0")]

namespace CSVFile.Application.CSVFiles
{
    public class FieldDto
    {
    public string Name { get; set; }
    public string Value { get; set; }
  }

  public class CSVFieldDto
  {
    public FieldDto Field { get; set; }
  }

}