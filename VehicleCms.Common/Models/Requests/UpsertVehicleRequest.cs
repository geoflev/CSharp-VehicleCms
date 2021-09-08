using FluentValidation;
using VehicleCms.Common.Models.Enums;

namespace VehicleCms.Common.Models.Requests
{
    public class UpsertVehicleRequest
    {
        public string Id { get; set; }
        public string Vin { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int ProductionYear { get; set; }
        public VehicleType Type { get; set; }
        public string UserId { get; set; }
    }

    public class UpsertVehicleRequestValidator : AbstractValidator<UpsertVehicleRequest>
    {
        public UpsertVehicleRequestValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Vin).NotEmpty();
            RuleFor(x => x.Make).NotEmpty();
            RuleFor(x => x.Model).NotEmpty();
            RuleFor(x => x.ProductionYear).NotEmpty();
            RuleFor(x => x.Type).NotEmpty();
            RuleFor(x => x.UserId).NotEmpty();
        }
    }
}
