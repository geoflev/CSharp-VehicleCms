using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using Hellang.Middleware.ProblemDetails;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System.Net.Http;
using VehicleCms.Common.Exceptions;

namespace VehicleCms.Api.Configurations
{
    public static class ProblemDetailsConfig
    {
        public static IServiceCollection AddProblemDetailsConfig(this IServiceCollection services, IWebHostEnvironment hostingEnvironment)
        {
            services.AddProblemDetails(options =>
            {
                options.IncludeExceptionDetails = (httpContext, exception) => hostingEnvironment.IsDevelopment();
                options.Map<BadRequestException>(e => new ValidationProblemDetails { Detail = e.Message });
                options.MapToStatusCode<ForbiddenException>(StatusCodes.Status403Forbidden);
                options.MapToStatusCode<NotFoundException>(StatusCodes.Status404NotFound);
                options.Map<NotImplementedException>(exception => new StatusCodeProblemDetails(StatusCodes.Status501NotImplemented));
                options.MapToStatusCode<HttpRequestException>(StatusCodes.Status503ServiceUnavailable);
                options.Map<Exception>(exception => new StatusCodeProblemDetails(StatusCodes.Status500InternalServerError));
            });
            return services;
        }
    }
}
