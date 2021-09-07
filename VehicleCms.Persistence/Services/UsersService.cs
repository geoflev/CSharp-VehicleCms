using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleCms.Common.Models.Dtos;
using VehicleCms.Common.Models.Requests;
using VehicleCms.Common.Services.Interfaces;

namespace VehicleCms.Persistence.Services
{
    public class UsersService : IUsersService
    {
        public VehicleCmsContext Context { get; }

        public UsersService(VehicleCmsContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Task<UserDto> CreateUser(string providerId, UpsertUserRequest upsertUserRequest)
        {
            throw new NotImplementedException();
        }

        public Task DeleteUser(string providerId, string userId)
        {
            throw new NotImplementedException();
        }

        public Task<UserDto> GetUser(string providerid, string userId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<UserDto>> GetUsers(string providerId)
        {
            var users = await Context
                .Users
                .AsNoTracking()
                .Where(x => x.ProviderId == providerId)
              .OrderBy(x => x.Name)
              .ToListAsync();
        }


        public Task<UserDto> UpdateUser(string providerId, string userId, UpsertUserRequest upsertUserRequest)
        {
            throw new NotImplementedException();
        }
    }
}
