using VehicleCms.Common.Models.Enums;
using VehicleCms.Persistence.Entities.Bases;

namespace VehicleCms.Persistence.Entities
{
    public class VehicleEntity : TrackableEntity
    {
        public string Vin { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int ProductionYear { get; set; }
        public VehicleType Type { get; set; }
        public string UserId { get; set; }
        public UserEntity User { get; set; }
    }
}
