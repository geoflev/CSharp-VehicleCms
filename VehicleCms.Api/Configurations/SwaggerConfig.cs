using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using VehicleCms.Common.Models.Settings;

namespace VehicleCms.Api.Configurations
{
    public static class SwaggerConfig
    {
        public static IServiceCollection AddSwaggerConfig(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("vehicle-console", new OpenApiInfo
                {
                    Version = "1.0.0.0",
                    Title = "Vehicle Console API"
                });
                options.EnableAnnotations();
                options.CustomOperationIds(idSelector => idSelector.ActionDescriptor.RouteValues["action"]);
                options.UseAllOfToExtendReferenceSchemas();
                options.UseAllOfForInheritance();
                options.UseOneOfForPolymorphism();
            });
            return services;
        }
    }
}
