using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CSVFile.Domain.Entities;
using Intent.RoslynWeaver.Attributes;

 
[assembly: IntentTemplate("Intent.Entities.Repositories.Api.EntityRepositoryInterface", Version = "1.0")]

namespace CSVFile.Domain.Repositories
{

  public interface ICSVFileRepository : IEFRepository<Domain.Entities.CSVFile, Domain.Entities.CSVFile>
  {
  

    void Add(Entities.CSVFile cSVFile);
    Task SaveChangesAsync(CancellationToken cancellationToken);
  }
}