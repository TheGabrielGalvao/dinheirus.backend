using System.ComponentModel.DataAnnotations.Schema;
using Util.Enumerator;

namespace Domain.Entities.Auth
{
    [Table("UserProfile", Schema = "auth")]
    public class UserProfile : DefaultEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ERegisterStatus Status { get; set; }

        public ICollection<Permission>? Permissions { get; set; }

        public ICollection<UserGroup>? UserGroups { get; set; }
    }
}
