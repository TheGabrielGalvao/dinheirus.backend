using Domain.Entities.Auth;
using Domain.Enum;
using System.ComponentModel.DataAnnotations.Schema;
using Util.Enumerartor;

namespace Domain.Entities.Fiancial
{
    [Table("FinancialReleaseType", Schema = "financial")]
    public class FinancialReleaseType : DefaultEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public EFinancialOperation Operation { get; set; }
        public EGenericStatus Status { get; set; }
        public long? UserId { get; set; }

        public User User { get; set; }
        public ICollection<FinancialRelease> FinancialReleases { get; set; }
    }
}