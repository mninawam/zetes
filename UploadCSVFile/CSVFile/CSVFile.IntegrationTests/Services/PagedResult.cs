using Intent.RoslynWeaver.Attributes;

 
[assembly: IntentTemplate("Intent.AspNetCore.IntegrationTesting.PagedResult", Version = "1.0")]

namespace CSVFile.IntegrationTests.Services
{
    public class PagedResult<TData>
    {
        public PagedResult()
        {
            Data = null!;
        }

        public int TotalCount { get; set; }
        public int PageCount { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public IEnumerable<TData> Data { get; set; }
    }
}