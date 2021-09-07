using VehicleCms.Common.Models.Requests.Bases;

namespace VehicleCms.Common.Models.Requests
{
    public class UpsertUserRequest : IdentifiableRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
