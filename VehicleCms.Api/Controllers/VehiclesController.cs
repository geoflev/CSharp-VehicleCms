using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Net;
using VehicleCms.Api.Controllers.Bases;
using VehicleCms.Common.Services.Interfaces;
using VehicleCms.Common.Models.Dtos;
using System.Threading.Tasks;
using VehicleCms.Common.Models.Requests;

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
            var vehicles = await VehiclesService.GetUserVehicles(userId);
            return Ok(vehicles);
        }

        [HttpPost()]
        [SwaggerOperation(Tags = new[] { "User  -  Vehicles" }, Summary = "Post vehicle")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(IEnumerable<VehicleDto>))]
        public async Task<IActionResult> PostUserVehicle([FromRoute] string userId, [FromBody] UpsertVehicleRequest request)
        {
            var vehicle = await VehiclesService.PostUserVehicle(userId, request);
            return Ok(vehicle);
        }

        [HttpPut("{vehicleId}")]
        [SwaggerOperation(Tags = new[] { "User  -  Vehicles" }, Summary = "Put vehicle")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(IEnumerable<VehicleDto>))]
        public async Task<IActionResult> PutUserVehicle([FromRoute] string userId, [FromRoute] string vehicleId, UpsertVehicleRequest request)
        {
            var vehicle = await VehiclesService.PutUserVehicle(userId, vehicleId, request);
            return Ok(vehicle);
        }

        [HttpDelete()]
        [SwaggerOperation(Tags = new[] { "User  -  Vehicles" }, Summary = "Put vehicle")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> DeleteUserVehicle([FromRoute] string userId, [FromRoute] string vehicleId)
        {
            await VehiclesService.DeleteUserVehicle(userId, vehicleId);
            return NoContent();
        }
    }
}
