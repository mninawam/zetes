using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVFile.Application.CSVFiles.CreateCSVFile
{

  public class CSVFileErrorException : Exception
  {
    public List<string> Errors { get; }

    public CSVFileErrorException(List<string> errors)
    {
      Errors = errors;
    }
  }

}
