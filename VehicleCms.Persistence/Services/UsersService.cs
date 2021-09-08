using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleCms.Common.Exceptions;
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

        public async Task<UserDto> GetUserById(string userId)
        {
            var user = await Context
                .Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Id == userId)
                ?? throw new NotFoundException($"The user with id {userId} not found.");

            return MapEntityToDto(user);
        }

        public async Task<UserDto> PostUser(UpsertUserRequest request)
        {
            var user = new UserEntity
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
            };
            await Context.Users.AddAsync(user);
            await Context.SaveChangesAsync();
            return MapEntityToDto(user);
        }
        public async Task<UserDto> PutUser(string userId, UpsertUserRequest upsertUserRequest)
        {
            var user = await Context
                .Users
                .FirstOrDefaultAsync(u => u.Id == userId)
                ?? throw new NotFoundException($"The user with id {userId} not found.");

            user.FirstName = upsertUserRequest.FirstName;
            user.LastName = upsertUserRequest.LastName;
            user.Email = upsertUserRequest.Email;

            Context.Users.Update(user);
            await Context.SaveChangesAsync();
            return MapEntityToDto(user);
        }

        public async Task DeleteUser(string userId)
        {
            var user = await Context
                .Users
                .FirstOrDefaultAsync(u => u.Id == userId)
                ?? throw new NotFoundException($"The user with kid {userId} was not found!");

            Context.Users.Remove(user);
            await Context.SaveChangesAsync();
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
