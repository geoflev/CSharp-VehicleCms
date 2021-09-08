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
    [Route("api/users")]
    public class UsersController : ApiControllerBase
    {
        public IUsersService UsersService { get; }

        public UsersController(IUsersService usersService)
        {
            UsersService = usersService ?? throw new ArgumentNullException(nameof(usersService));
        }

        [HttpGet()]
        [SwaggerOperation(Tags = new[] { "Users" }, Summary = "Get all users")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(IEnumerable<UserDto>))]
        public async Task<IActionResult> GetUsers()
        {
            var services = await UsersService.GetUsers();
            return Ok(services);
        }

        [HttpGet("{userId}")]
        [SwaggerOperation(Tags = new[] { "Users" }, Summary = "Get user")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(UserDto))]
        public async Task<IActionResult> GetUserById([FromRoute] string userId)
        {
            var service = await UsersService.GetUserById(userId);
            return Ok(service);
        }

        [HttpPost()]
        [SwaggerOperation(Tags = new[] { "Users" }, Summary = "Save User")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(UserDto))]
        public async Task<IActionResult> PostUser([FromBody] UpsertUserRequest request)
        {
            var service = await UsersService.PostUser(request);
            return Ok(service);
        }

        [HttpPut("{userId}")]
        [SwaggerOperation(Tags = new[] { "Users" }, Summary = "Update User")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(UserDto))]
        public async Task<IActionResult> PutUser([FromRoute] string userId, [FromBody] UpsertUserRequest request)
        {
            var service = await UsersService.PutUser(userId, request);
            return Ok(service);
        }

        [HttpDelete("{userId}")]
        [SwaggerOperation(Tags = new[] { "Users" }, Summary = "Delete User")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> DeleteUser([FromRoute] string userId)
        {
            await UsersService.DeleteUser(userId);
            return NoContent();
        }
    }
}
