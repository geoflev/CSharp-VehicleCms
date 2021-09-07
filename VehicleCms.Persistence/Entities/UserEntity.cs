using System;
using System.Collections.Generic;
using System.Text;

namespace VehicleCms.Persistence.Entities
{
    public class UserEntity
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public ICollection<VehicleEntity> Vehicles { get; set; }
    }
}
