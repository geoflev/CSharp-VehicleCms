using System.Collections.Generic;
using VehicleCms.Persistence.Entities.Bases;

namespace VehicleCms.Persistence.Entities
{
    public class UserEntity : TrackableEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public ICollection<VehicleEntity> Vehicles { get; set; }
    }
}
