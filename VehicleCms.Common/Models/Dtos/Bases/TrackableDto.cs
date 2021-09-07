using System;

namespace VehicleCms.Common.Models.Dtos.Bases
{
    public class TrackableDto
    {
        public string CreatedBy { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public string ModifiedBy { get; set; }
        public DateTimeOffset? ModifiedAt { get; set; }
    }
}