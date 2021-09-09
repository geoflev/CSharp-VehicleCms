using Microsoft.Extensions.Configuration;
using VehicleCms.Persistence;
using System.Reflection;

using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace VehicleCms.Api.Configurations
{
    public static class DbConfig
    {
        public static IServiceCollection AddDatabaseConfig(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment hostingEnvironment)
        {
            services.AddDbContext<VehicleCmsContext>(builder =>
            {
                if (hostingEnvironment.IsDevelopment())
                {
                    builder.EnableDetailedErrors();
                    builder.EnableSensitiveDataLogging();
                }
                var migrationsAssembly = typeof(VehicleCmsContext).GetTypeInfo().Assembly.GetName().Name;
                builder.UseSqlServer(configuration.GetConnectionString("VehicleCms"), options => options.MigrationsAssembly(migrationsAssembly));
            });
            return services;
        }
    }
}
