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
        Task<UserDto> GetUserById(string userId);
        Task<UserDto> PostUser(UpsertUserRequest upsertUserRequest);
        Task<UserDto> PutUser(string userId, UpsertUserRequest upsertUserRequest);
        Task DeleteUser(string userId);
    }
}
