using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CSVFile.Domain.Entities;
using CSVFile.Domain.Repositories;
using CSVFile.Infrastructure.Persistence;
using Intent.RoslynWeaver.Attributes;

 
[assembly: IntentTemplate("Intent.EntityFrameworkCore.Repositories.Repository", Version = "1.0")]

namespace CSVFile.Infrastructure.Repositories
{
  [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
  public class CSVFileRepository : RepositoryBase<Domain.Entities.CSVFile, Domain.Entities.CSVFile, ApplicationDbContext>, ICSVFileRepository
  {

    private readonly ApplicationDbContext _context;

    public CSVFileRepository(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
    {
      _context = dbContext;
    }

    public async Task<Domain.Entities.CSVFile?> FindByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default)
    {
      return await FindAsync(x => x.Id == id, cancellationToken);
    }

    public void Add(Domain.Entities.CSVFile cSVFile)
    {
      _context.CSVFiles.Add(cSVFile);
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
      await _context.SaveChangesAsync(cancellationToken);
    }
  }
}