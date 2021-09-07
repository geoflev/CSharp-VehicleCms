using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using VehicleCms.Api.Controllers.Bases;
using VehicleCms.Common.Models.Dtos;
using VehicleCms.Common.Models.Requests;
using VehicleCms.Common.Services.Interfaces;

namespace VehicleCms.Api.Controllers
{
    public class UsersController : ApiControllerBase
    {
        public IUsersService UsersService { get; }

        public UsersController(IUsersService usersService)
        {
            UsersService = usersService ?? throw new ArgumentNullException(nameof(usersService));
        }

        [HttpGet()]
        [SwaggerOperation(Tags = new[] { "Provider - Users" }, Summary = "Get users")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(IEnumerable<UserDto>))]
        public async Task<IActionResult> GetUsers([FromRoute] string providerId)
        {
            var services = await UsersService.GetUsers(providerId);
            return Ok(services);
        }

        [HttpGet("{userId}")]
        [SwaggerOperation(Tags = new[] { "Provider - Users" }, Summary = "Get user")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(UserDto))]
        public async Task<IActionResult> GetUserById([FromRoute] string providerId, string userId)
        {
            var service = await UsersService.GetUser(providerId, userId);
            return Ok(service);
        }

        [HttpPost()]
        [SwaggerOperation(Tags = new[] { "Provider - Users" }, Summary = "Save User")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(UserDto))]
        public async Task<IActionResult> PostUser([FromRoute] string providerId, [FromBody] UpsertUserRequest request)
        {
            var service = await UsersService.CreateUser(providerId, request);
            return Ok(service);
        }

        [HttpPut("{userId}")]
        [SwaggerOperation(Tags = new[] { "Provider - Users" }, Summary = "Update User")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(UserDto))]
        public async Task<IActionResult> PutUser([FromRoute] string providerId, [FromRoute] string userId, [FromBody] UpsertUserRequest request)
        {
            var service = await UsersService.UpdateUser(providerId, userId, request);
            return Ok(service);
        }

        [HttpDelete("{userId}")]
        [SwaggerOperation(Tags = new[] { "Provider - Users" }, Summary = "Delete User")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> DeleteUser([FromRoute] string providerId, [FromRoute] string userId)
        {
            await UsersService.DeleteUser(providerId, userId);
            return NoContent();
        }
    }
}
