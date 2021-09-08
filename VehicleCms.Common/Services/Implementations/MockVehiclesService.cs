using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VehicleCms.Common.Models.Dtos;
using VehicleCms.Common.Models.Requests;
using VehicleCms.Common.Services.Interfaces;

namespace VehicleCms.Common.Services.Implementations
{
    class MockVehiclesService : IVehiclesService
    {
        public async Task DeleteUserVehicle(string userId, string vehicleId)
        {
            await Task.Delay(500);
        }

        public async Task<IEnumerable<VehicleDto>> GetUserVehicles(string userId)
        {
            await Task.Delay(500);
            return new VehicleFaker().Generate(10);
        }

        public async Task<VehicleDto> PostUserVehicle(string userId, UpsertVehicleRequest request)
        {
            await Task.Delay(500);
            return new VehicleFaker().Generate();
        }

        public async Task<VehicleDto> PutUserVehicle(string userId, string vehicleId, UpsertVehicleRequest request)
        {
            await Task.Delay(500);
            return new VehicleFaker().Generate();
        }
    }
}
