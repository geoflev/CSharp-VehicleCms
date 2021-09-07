using VehicleCms.Common.Models.Dtos.Bases;
using VehicleCms.Common.Models.Enums;

namespace VehicleCms.Common.Models.Dtos
{
    public class VehicleDto : TrackableDto
    {
        public string Id { get; set; }
        public string Vin { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int ProductionYear { get; set; }
        public VehicleType Type { get; set; }
        public string UserId { get; set; }
    }
}
