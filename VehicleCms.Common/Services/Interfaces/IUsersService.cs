using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VehicleCms.Common.Models.Dtos;
using VehicleCms.Common.Models.Requests;

namespace VehicleCms.Common.Services.Interfaces
{
    public interface IUsersService
    {
        Task<IEnumerable<UserDto>> GetUsers(string providerId);
        Task<UserDto> GetUser(string providerid, string userId);
        Task<UserDto> CreateUser(string providerId, UpsertUserRequest upsertUserRequest);
        Task<UserDto> UpdateUser(string providerId, string userId, UpsertUserRequest upsertUserRequest);
        Task DeleteUser(string providerId, string userId);
    }
}
