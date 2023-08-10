using Domain.Entities.Auth;
using Domain.Entities.Fiancial;
using Domain.Enum;
using Domain.Model.Contact;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Model.Financial
{
    public class FinancialReleaseResponse
    {
        public Guid? Uuid { get; set; }
        public string Title { get; set; }
        public decimal Value { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public EFinancialReleaseStatus Status { get; set; }
        public EFinancialOperation Operation { get; set; }
        public Guid FinancialReleaseTypeUuid { get; set; }
        public Guid UserUuid { get; set; }
        public Guid? ContactUuid { get; set; }

    }
}
