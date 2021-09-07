using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Net;
using VehicleCms.Api.Controllers.Bases;
using VehicleCms.Common.Services.Interfaces;
using VehicleCms.Common.Models.Dtos;
using System.Threading.Tasks;

namespace VehicleCms.Api.Controllers
{
    [Route("api/users/{userId}/vehicles")]
    public class VehiclesController : ApiControllerBase
    {
        public IVehiclesService VehiclesService { get; }

        public VehiclesController(IVehiclesService vehiclesService)
        {
            VehiclesService = vehiclesService ?? throw new ArgumentNullException(nameof(vehiclesService));
        }

        [HttpGet()]
        [SwaggerOperation(Tags = new[] { "User  -  Vehicles" }, Summary = "Get vehicles")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(IEnumerable<VehicleDto>))]
        public async Task<IActionResult> GetUserVehicles([FromRoute] string userId)
        {
            var services = await VehiclesService.
        }
    }
}
