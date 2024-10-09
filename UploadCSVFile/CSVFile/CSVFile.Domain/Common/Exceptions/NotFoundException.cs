using System;
using Intent.RoslynWeaver.Attributes;

 
[assembly: IntentTemplate("Intent.Entities.NotFoundException", Version = "1.0")]

namespace CSVFile.Domain.Common.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message)
        {
        }
    }
}