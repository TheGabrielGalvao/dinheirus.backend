using System.ComponentModel.DataAnnotations.Schema;
using Util.Enumerator;

namespace Domain.Entities.Auth
{
    [Table("Users", Schema = "auth")]
    public class User : DefaultEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string? Password { get; set; }
        public ERegisterStatus? Status { get; set; } = ERegisterStatus.ACTIVE;

        public long ProfileId { get; set; }

        [ForeignKey(nameof(ProfileId))]
        public UserProfile Profile { get; set; }

        public long? UserGroupId { get; set; }

        [ForeignKey(nameof(UserGroupId))]
        [InverseProperty("Users")]
        public UserGroup UserGroup { get; set; }
    }

}
