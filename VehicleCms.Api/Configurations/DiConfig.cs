using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using VehicleCms.Common.Models.Settings;
using VehicleCms.Common.Services.Decorators;
using VehicleCms.Common.Services.Interfaces;
using VehicleCms.Persistence.Services;

namespace VehicleCms.Api.Configurations
{
    public static class DiConfig
    {
        public static IServiceCollection AddCustomServices(this IServiceCollection services, IConfiguration configuration, GeneralSettings settings)
        {
            services.Configure<GeneralSettings>(configuration.GetSection(GeneralSettings.Name));

            services.AddScoped<IUsersService, UsersService>();

            services.Decorate<IUsersService, CacheUsersService>();

            return services;
        }
    }
}
