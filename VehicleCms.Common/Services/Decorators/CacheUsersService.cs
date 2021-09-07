using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VehicleCms.Common.Models.Dtos;
using VehicleCms.Common.Models.Requests;
using VehicleCms.Common.Services.Decorators.Bases;
using VehicleCms.Common.Services.Interfaces;
using Microsoft.Extensions.Caching.Distributed;

namespace VehicleCms.Common.Services.Decorators
{
    public class CacheUsersService : DecoratorBase, IUsersService
    {
        public override string CacheKeyBase => "Users";
        public IUsersService UsersService { get; }

        public CacheUsersService(IUsersService usersService, IDistributedCache distributedCache) : base(distributedCache)
        {
            UsersService = usersService ?? throw new ArgumentNullException(nameof(usersService));
        }

        public async Task<IEnumerable<UserDto>> GetUsers(string providerId)
        {
            var users = await GetFromCacheOrHttp($"{providerId}-{CacheKeyBase}",
                async () => await UsersService.GetUsers(providerId));
            return users;
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

        

        public Task<UserDto> UpdateUser(string providerId, string userId, UpsertUserRequest upsertUserRequest)
        {
            throw new NotImplementedException();
        }
    }
}
