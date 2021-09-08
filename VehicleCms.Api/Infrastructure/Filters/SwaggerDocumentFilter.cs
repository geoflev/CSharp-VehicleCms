using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Linq;

namespace VehicleCms.Api.Infrastructure.Filters
{
    public class SwaggerDocumentFilter : IDocumentFilter
    {
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            var openApiPaths = new OpenApiPaths();
            foreach (var path in swaggerDoc.Paths.OrderBy(x => x.Key))
            {
                openApiPaths.Add(path.Key, path.Value);
            }
            swaggerDoc.Paths = openApiPaths;
        }
    }
}
