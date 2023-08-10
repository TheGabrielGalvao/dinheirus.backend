using System.ComponentModel.DataAnnotations.Schema;
using Util.Enumerator;

namespace Domain.Entities.Auth
{
    [Table("Permission", Schema = "auth")]
    public class Permission : DefaultEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Key { get; set; }
        public int Type { get; set; }
        public ERegisterStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool NeedSupervision { get; set; }

        public ICollection<UserProfile>? Profiles { get; set; }
        public long ModuleId { get; set; }

        [ForeignKey(nameof(ModuleId))]
        public Module Module { get; set; }
    }
}
