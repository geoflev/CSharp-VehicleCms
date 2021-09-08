using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VehicleCms.Common.Models.Dtos;
using VehicleCms.Common.Models.Requests;
using VehicleCms.Common.Services.Decorators.Bases;
using VehicleCms.Common.Services.Interfaces;

namespace VehicleCms.Common.Services.Decorators
{
    public class CacheVehiclesService : DecoratorBase, IVehiclesService
    {
        public override string CacheKeyBase => "Vehicles";

        public IVehiclesService VehiclesService { get; set; }

        public CacheVehiclesService(IVehiclesService vehiclesService, IDistributedCache distributedCache) : base(distributedCache)
        {
            VehiclesService = vehiclesService ?? throw new ArgumentNullException(nameof(vehiclesService));
        }

        public async Task<IEnumerable<VehicleDto>> GetUserVehicles(string userId)
        {
            var vehicles = await GetFromCacheOrHttp($"{userId}-{CacheKeyBase}",
               async () => await VehiclesService.GetUserVehicles(userId));
            return vehicles;
        }

        public async Task<VehicleDto> PostUserVehicle(string userId, UpsertVehicleRequest request)
        {
            var vehicle = await VehiclesService.PostUserVehicle(userId, request);
            await ClearCache($"{userId}-{CacheKeyBase}");
            return vehicle;
        }

        public async Task<VehicleDto> PutUserVehicle(string userId, string vehicleId, UpsertVehicleRequest request)
        {
            var service = await VehiclesService.PutUserVehicle(userId, vehicleId, request);
            await ClearCache($"{userId}-{CacheKeyBase}");
            await ClearCache($"{userId}-{CacheKeyBase}-{vehicleId}");
            return service;
        }

        public async Task DeleteUserVehicle(string userId, string vehicleId)
        {
            await VehiclesService.DeleteUserVehicle(userId, vehicleId);
            await ClearCache($"{userId}-{CacheKeyBase}");
            await ClearCache($"{userId}-{CacheKeyBase}-{vehicleId}");
        }
    }
}
