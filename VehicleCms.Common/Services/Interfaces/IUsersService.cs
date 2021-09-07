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
        Task<IEnumerable<UserDto>> GetUsers();
        Task<UserDto> GetUser(string userId);
        Task<UserDto> CreateUser(UpsertUserRequest upsertUserRequest);
        Task<UserDto> UpdateUser(string userId, UpsertUserRequest upsertUserRequest);
        Task DeleteUser(string userId);
    }
}
