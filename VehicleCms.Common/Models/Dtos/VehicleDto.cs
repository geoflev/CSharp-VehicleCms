using Bogus;
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

    public class VehicleFaker : Faker<VehicleDto>
    {
        public VehicleFaker()
        {
            RuleFor(x => x.Id, f => f.Random.Guid().ToString());
            RuleFor(x => x.Vin, f => f.Vehicle.Vin());
            RuleFor(x => x.Make, f => f.Vehicle.Manufacturer());
            RuleFor(x => x.Model, f => f.Vehicle.Model());
            RuleFor(o => o.ProductionYear, f =>
             {
                 var date = f.Date.Past();
                 return date.Year;
             });
            RuleFor(x => x.UserId, f => f.Random.Guid().ToString());
        }
    }
}
