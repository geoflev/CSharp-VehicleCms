using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VehicleCms.Common.Services.Decorators;
using VehicleCms.Common.Services.Implementations;
using VehicleCms.Common.Services.Interfaces;
using VehicleCms.Persistence.Services;

namespace VehicleCms.Api.Configurations
{
    public static class DiConfig
    {
        public static IServiceCollection AddCustomServices(this IServiceCollection services, IConfiguration configuration)
        {
            if (configuration.GetSection("UseMock").Get<bool>())
            {
                services.AddScoped<IUsersService, MockUsersService>();
                services.AddScoped<IVehiclesService, MockVehiclesService>();
            }
            else
            {
                services.AddScoped<IUsersService, UsersService>();
                services.AddScoped<IVehiclesService, VehiclesService>();
            }

            services.Decorate<IUsersService, CacheUsersService>();
            services.Decorate<IVehiclesService, CacheVehiclesService>();

            return services;
        }
    }
}
