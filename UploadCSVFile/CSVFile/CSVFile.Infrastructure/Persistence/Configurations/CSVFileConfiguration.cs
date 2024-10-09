using CSVFile.Domain.Entities;
using Intent.RoslynWeaver.Attributes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

 
[assembly: IntentTemplate("Intent.EntityFrameworkCore.EntityTypeConfiguration", Version = "1.0")]

namespace CSVFile.Infrastructure.Persistence.Configurations
{
    public class CSVFileConfiguration : IEntityTypeConfiguration<Domain.Entities.CSVFile>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.CSVFile> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Ignore(e => e.DomainEvents);
        }
    }
}