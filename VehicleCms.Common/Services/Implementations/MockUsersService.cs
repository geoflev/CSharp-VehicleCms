using System.Collections.Generic;
using System.Threading.Tasks;
using VehicleCms.Common.Models.Dtos;
using VehicleCms.Common.Models.Requests;
using VehicleCms.Common.Services.Interfaces;

namespace VehicleCms.Common.Services.Implementations
{
    public class MockUsersService : IUsersService
    {
        public async Task DeleteUser(string userId)
        {
            await Task.Delay(500);
        }

        public async Task<UserDto> GetUserById(string userId)
        {
            await Task.Delay(500);
            return new UserFaker().Generate();
        }

        public async Task<IEnumerable<UserDto>> GetUsers()
        {
            await Task.Delay(500);
            return new UserFaker().Generate(10);
        }

        public async Task<UserDto> PostUser(UpsertUserRequest upsertUserRequest)
        {
            await Task.Delay(500);
            return new UserFaker().Generate();

        }

        public async Task<UserDto> PutUser(string userId, UpsertUserRequest upsertUserRequest)
        {
            await Task.Delay(500);
            return new UserFaker().Generate();
        }
    }
}
