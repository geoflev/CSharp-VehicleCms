using System.Collections.Generic;
using System.Threading.Tasks;
using VehicleCms.Common.Models.Dtos;
using VehicleCms.Common.Models.Requests;

namespace VehicleCms.Common.Services.Interfaces
{
    public interface IVehiclesService
    {
        Task<IEnumerable<VehicleDto>> GetUserVehicles(string userId);
        Task<VehicleDto> PostUserVehicle(string userId, UpsertVehicleRequest request);
        Task<VehicleDto> PutUserVehicle(string userId, string vehicleId, UpsertVehicleRequest request);
        Task DeleteUserVehicle(string userId, string vehicleId);
    }
}
