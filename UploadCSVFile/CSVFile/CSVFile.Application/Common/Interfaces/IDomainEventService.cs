using System.Threading;
using System.Threading.Tasks;
using CSVFile.Domain.Common;
using Intent.RoslynWeaver.Attributes;

 
[assembly: IntentTemplate("Intent.DomainEvents.DomainEventServiceInterface", Version = "1.0")]

namespace CSVFile.Application.Common.Interfaces
{
    public interface IDomainEventService
    {
        Task Publish(DomainEvent domainEvent, CancellationToken cancellationToken = default);
    }
}