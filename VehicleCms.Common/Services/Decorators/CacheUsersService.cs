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
        private string MappingsKey => "Vehicles";

        public IUsersService UsersService { get; }

        public CacheUsersService(IUsersService usersService, IDistributedCache distributedCache) : base(distributedCache)
        {
            UsersService = usersService ?? throw new ArgumentNullException(nameof(usersService));
        }

        public async Task<IEnumerable<UserDto>> GetUsers()
        {
            var users = await GetFromCacheOrHttp($"{CacheKeyBase}",
                async () => await UsersService.GetUsers());
            return users;
        }

        public async Task<UserDto> GetUserById(string userId)
        {
            var user = await GetFromCacheOrHttp($"{CacheKeyBase}",
                async () => await UsersService.GetUserById(userId));
            return user;
        }

        public async Task<UserDto> PostUser(UpsertUserRequest upsertUserRequest)
        {
            var solution = await UsersService.PostUser(upsertUserRequest);
            await ClearCache($"{CacheKeyBase}");
            await ClearCache($"{MappingsKey}");
            return solution;
        }

        public async Task<UserDto> PutUser(string userId, UpsertUserRequest upsertUserRequest)
        {
            var solution = await UsersService.PutUser(userId, upsertUserRequest);
            await ClearCache($"{CacheKeyBase}");
            await ClearCache($"{CacheKeyBase}-{userId}");
            await ClearCache($"{MappingsKey}");
            return solution;
        }

        public async Task DeleteUser(string userId)
        {
            await UsersService.DeleteUser(userId);
            await ClearCache($"{CacheKeyBase}");
            await ClearCache($"{CacheKeyBase}-{userId}");
            await ClearCache($"{MappingsKey}");
        }
    }
}
