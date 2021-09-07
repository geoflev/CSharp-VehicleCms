using System;
using System.Collections.Generic;
using System.Text;

namespace VehicleCms.Persistence.Entities.Connectors
{
     public class UserVehicleConnectorEntity
    {
        public string UserId { get; set; }
        public virtual UserEntity User { get; set; }

        public string VehicleId { get; set; }
        public virtual VehicleEntity Vehicle { get; set; }
    }
}
