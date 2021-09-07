using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace VehicleCms.Api.Controllers.Bases
{
    [ApiController]
    [Produces("application/json")]
    [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(ValidationProblemDetails))]
    [ProducesResponseType((int)HttpStatusCode.Unauthorized, Type = typeof(ProblemDetails))]
    [ProducesResponseType((int)HttpStatusCode.Forbidden, Type = typeof(ProblemDetails))]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(ProblemDetails))]
    public class ApiControllerBase : ControllerBase
    {
    }
}
