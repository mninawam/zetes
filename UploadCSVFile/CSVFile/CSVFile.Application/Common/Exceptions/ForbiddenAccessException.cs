using System;
using Intent.RoslynWeaver.Attributes;

namespace CSVFile.Application.Common.Exceptions
{
    public class ForbiddenAccessException : Exception
    {
        public ForbiddenAccessException() : base() { }
    }
}