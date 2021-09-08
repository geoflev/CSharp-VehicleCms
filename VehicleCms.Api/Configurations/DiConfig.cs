using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VehicleCms.Common.Models.Settings;
using VehicleCms.Common.Services.Decorators;
using VehicleCms.Common.Services.Interfaces;
using VehicleCms.Persistence.Services;

namespace VehicleCms.Api.Configurations
{
    public static class DiConfig
    {
        public static IServiceCollection AddCustomServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUsersService, UsersService>();
            services.AddScoped<IVehiclesService, VehiclesService>();

            services.Decorate<IUsersService, CacheUsersService>();
            services.Decorate<IVehiclesService, CacheVehiclesService>();

            return services;
        }
    }
}
