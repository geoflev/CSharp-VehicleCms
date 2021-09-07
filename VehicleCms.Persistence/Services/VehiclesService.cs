using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VehicleCms.Common.Services.Interfaces;
using VehicleCms.Common.Exceptions;
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
                .Where(vehicle => vehicle.UserId == userId)
                .OrderBy(x => x.Make)
                .ToListAsync();
            return vehicles.Select(veh => MapEntityToDto(veh));
        }

        public async Task<VehicleDto> PostUserVehicle(string userId, UpsertVehicleRequest request)
        {
            if (!await Context.VehicleConnectors.AsNoTracking().AnyAsync(x => x.UserId == userId && x.VehicleId == request.Id))
            {
                throw new BadRequestException($"The selected connector is not assigned to the provider.");
            }

            var vehicle = new VehicleEntity
            {
                Id = request.Id,
                Vin = request.Vin,
                Make = request.Make,
                Model = request.Model,
                ProductionYear = request.ProductionYear,
                Type = request.Type,
                UserId = userId,
            };
            await Context.Vehicles.AddAsync(vehicle);
            await Context.SaveChangesAsync();
            return MapEntityToDto(vehicle);
        }

        public async Task<VehicleDto> PutUserVehicle(string userId, string vehicleId, UpsertVehicleRequest request)
        {
            var vehicle = await Context
                .Vehicles
                .FirstOrDefaultAsync(v => v.UserId == userId && v.Id == vehicleId)
                ?? throw new NotFoundException($"The user with id {userId} not found.");

            if (!await Context.VehicleConnectors.AsNoTracking().AnyAsync(x => x.UserId == userId && x.VehicleId == request.Id))
            {
                throw new BadRequestException($"The selected connector is not assigned to the provider.");
            }
            vehicle.Vin = request.Vin;
            vehicle.Make = request.Make;
            vehicle.Model = request.Model;
            vehicle.ProductionYear = request.ProductionYear;
            vehicle.Type = request.Type;
            vehicle.UserId = request.UserId;

            Context.Vehicles.Update(vehicle);
            await Context.SaveChangesAsync();
            return MapEntityToDto(vehicle);
        }

        public async Task DeleteUserVehicle(string vehicleId, string userId)
        {
            var vehicle = await Context
                .Vehicles
                .FirstOrDefaultAsync(v => v.UserId == userId && v.Id == vehicleId)
                ?? throw new NotFoundException($"The user with id {userId} not found.");
            Context.Vehicles.Remove(vehicle);
            await Context.SaveChangesAsync();
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
