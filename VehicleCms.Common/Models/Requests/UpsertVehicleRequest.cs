using VehicleCms.Common.Models.Enums;

namespace VehicleCms.Common.Models.Requests
{
    public class UpsertVehicleRequest
    {
        public string Id { get; set; }
        public string Vin { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int ProductionYear { get; set; }
        public VehicleType Type { get; set; }
    }
}
