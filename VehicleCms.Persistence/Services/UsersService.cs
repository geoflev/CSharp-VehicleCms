using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleCms.Common.Models.Dtos;
using VehicleCms.Common.Models.Requests;
using VehicleCms.Common.Services.Interfaces;
using VehicleCms.Persistence.Entities;

namespace VehicleCms.Persistence.Services
{
    public class UsersService : IUsersService
    {
        public VehicleCmsContext Context { get; }

        public UsersService(VehicleCmsContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<UserDto>> GetUsers()
        {
            var users = await Context
                .Users
                .AsNoTracking()
              .OrderBy(x => x.LastName)
              .ToListAsync();

            return users.Select(user => MapEntityToDto(user));
        }

        public Task<UserDto> GetUser(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<UserDto> CreateUser(UpsertUserRequest upsertUserRequest)
        {
            throw new NotImplementedException();
        }
        public Task<UserDto> UpdateUser(string userId, UpsertUserRequest upsertUserRequest)
        {
            throw new NotImplementedException();
        }

        public Task DeleteUser(string userId)
        {
            throw new NotImplementedException();
        }

        private UserDto MapEntityToDto(UserEntity user)
        {
            return new UserDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
            };
        }
    }
}
