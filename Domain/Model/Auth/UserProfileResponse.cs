using Domain.Entities.Auth;
using Util.Enumerator;

namespace Domain.Model.Auth
{
    public class UserProfileResponse
    {
        public Guid? Uuid { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ERegisterStatus Status { get; set; }

        public ICollection<Permission>? Permissions { get; set; }

        public ICollection<UserGroup>? UserGroups { get; set; }
    }
}
