using Domain.Entities.Fiancial;
using Domain.Enum;

namespace Domain.Model.Financial
{
    public class FinancialReleaseRequest
    {
        public Guid? Uuid { get; set; }
        public string Title { get; set; }
        public decimal Value { get; set; }
        public EFinancialReleaseStatus? Status { get; set; }
        public EFinancialOperation Operation { get; set; }
        public Guid FinancialReleaseTypeUuid { get; set; }
        public Guid? ContactUuid { get; set; }
    }
}
