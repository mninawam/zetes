using System.Threading.Tasks;
using Intent.RoslynWeaver.Attributes;

 
 

namespace CSVFile.Application.Common.Interfaces
{
    public interface ICurrentUserService
    {
        string? UserId { get; }
        string? UserName { get; }
        Task<bool> IsInRoleAsync(string role);
        Task<bool> AuthorizeAsync(string policy);
    }
}