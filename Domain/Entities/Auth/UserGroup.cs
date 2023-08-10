using System.ComponentModel.DataAnnotations.Schema;
using Util.Enumerator;

namespace Domain.Entities.Auth
{
    [Table("UserGroup", Schema = "auth")]
    public class UserGroup : DefaultEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ERegisterStatus Status { get; set; }

        public long ProfileId { get; set; }

        [ForeignKey(nameof(ProfileId))]
        public UserProfile Profile { get; set; }

        [InverseProperty("UserGroup")]
        public List<User> Users { get; set; }
    }
}
