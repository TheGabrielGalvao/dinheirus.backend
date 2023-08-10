using Domain.Entities.Auth;
using Domain.Enum;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Fiancial
{
    [Table("FinancialRelease", Schema = "financial")]
    public class FinancialRelease : DefaultEntity
    {
        public string Title { get; set; }
        public decimal Value { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;  
        public EFinancialReleaseStatus Status { get; set; }
        public EFinancialOperation Operation { get; set; }
        public long FinancialReleaseTypeId { get; set; }
        
        [ForeignKey(nameof(FinancialReleaseTypeId))]
        public FinancialReleaseType FinancialReleaseType { get; set; }

        public long UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public User User { get; set; }

        public long? ContactId { get; set; }

        public Contact Contact { get; set; }
    }
}