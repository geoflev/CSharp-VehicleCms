using System;
using System.Collections.Generic;
using System.Text;

namespace VehicleCms.Persistence.Entities.Bases
{
    class TrackableEntity
    {
        public string CreatedBy { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public string ModifiedBy { get; set; }
        public DateTimeOffset? ModifiedAt { get; set; }
    }
}
