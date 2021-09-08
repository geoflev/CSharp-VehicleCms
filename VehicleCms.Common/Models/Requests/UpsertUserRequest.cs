using FluentValidation;
using VehicleCms.Common.Models.Requests.Bases;

namespace VehicleCms.Common.Models.Requests
{
    public class UpsertUserRequest : IdentifiableRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }

    public class UpsertUserRequestValidator : AbstractValidator<UpsertUserRequest>
    {
        public UpsertUserRequestValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty();
            RuleFor(x => x.Email).EmailAddress();
            
        }
    }
}
