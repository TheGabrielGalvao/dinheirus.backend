using System.ComponentModel.DataAnnotations.Schema;
using Util.Enumerator;

namespace Domain.Entities.Auth
{
    [Table("Module", Schema = "auth")]
    public class Module : DefaultEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Key { get; set; }
        public int Type { get; set; }
        public ERegisterStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public ICollection<Permission> Permissions { get; set; }
    }
}
