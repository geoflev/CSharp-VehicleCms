using Bogus;
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

    public class UserFaker : Faker<UserDto>
    {
        public UserFaker()
        {
            RuleFor(x => x.Id, f => f.Random.Guid().ToString());
            RuleFor(x => x.FirstName, f => f.Person.FirstName);
            RuleFor(x => x.LastName, f => f.Person.LastName);
            RuleFor(x => x.Email, f => f.Person.Email);
        }
    }
}
