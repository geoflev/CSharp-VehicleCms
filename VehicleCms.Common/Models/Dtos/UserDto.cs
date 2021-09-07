using System;
using System.Collections.Generic;
using System.Text;
using VehicleCms.Common.Models.Dtos.Bases;

namespace VehicleCms.Common.Models.Dtos
{
    public class UserDto : TrackableDto
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
