using System;
using System.Collections.Generic;
using System.Text;
using VehicleCms.Common.Models.Enums;

namespace VehicleCms.Persistence.Entities
{
    public class VehicleEntity
    {
        public string Id { get; set; }
        public string Vin { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int ProductionYear { get; set; }
        public VehicleType Type { get; set; }
        public string UserId { get; set; }
        public UserEntity User { get; set; }
    }
}
