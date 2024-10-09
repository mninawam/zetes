using CSVFile.Application.Common.Interfaces;
using CSVFile.Domain.Common.Interfaces;
using CSVFile.Domain.Repositories;
using CSVFile.Infrastructure.Persistence;
using CSVFile.Infrastructure.Repositories;
using CSVFile.Infrastructure.Services;
using Intent.RoslynWeaver.Attributes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

 
[assembly: IntentTemplate("Intent.Infrastructure.DependencyInjection.DependencyInjection", Version = "1.0")]

namespace CSVFile.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>((sp, options) =>
            {
                options.UseInMemoryDatabase("DefaultConnection");
                options.UseLazyLoadingProxies();
            });
            services.AddScoped<IUnitOfWork>(provider => provider.GetRequiredService<ApplicationDbContext>());
            services.AddTransient<ICSVFileRepository, CSVFileRepository>();
            services.AddScoped<IDomainEventService, DomainEventService>();
            return services;
        }
    }
}