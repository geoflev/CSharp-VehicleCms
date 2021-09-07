using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VehicleCms.Common.Services.Interfaces;
using VehicleCms.Common.Models.Dtos;
using Microsoft.EntityFrameworkCore;
using VehicleCms.Common.Models.Requests;
using System.Linq;
using VehicleCms.Persistence.Entities;

namespace VehicleCms.Persistence.Services
{
    public class VehiclesService : IVehiclesService
    {
        public VehicleCmsContext Context { get; }

        public VehiclesService(VehicleCmsContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<VehicleDto>> GetUserVehicles(string userId)
        {
            var vehicles = await Context
                .Vehicles
                .AsNoTracking()
                .OrderBy(x => x.Make)
                .ToListAsync();
            return vehicles.Select(veh => MapEntityToDto(veh));
        }

        public Task<VehicleDto> PostUserVehicle(string userId, UpsertVehicleRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<VehicleDto> PutUserVehicle(string userId, string vehicleId, UpsertVehicleRequest request)
        {
            throw new NotImplementedException();
        }

        public Task DeleteUserVehicle(string vehicleId, string userId)
        {
            throw new NotImplementedException();
        }

        private VehicleDto MapEntityToDto(VehicleEntity entity)
        {
            return new VehicleDto
            {
                Id = entity.Id,
                Vin = entity.Vin,
                Make = entity.Make,
                Model = entity.Model,
                ProductionYear = entity.ProductionYear,
                Type = entity.Type,
                UserId = entity.UserId,
            };
        }

    }
}
