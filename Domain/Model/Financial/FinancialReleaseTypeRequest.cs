using Domain.Enum;
using Util.Enumerartor;

namespace Domain.Model.Financial
{
    public class FinancialReleaseTypeRequest
    {
        public Guid? Uuid { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public EFinancialOperation Operation { get; set; }
        public EGenericStatus Status { get; set; }
        public Guid? UserUuid { get; set; }
    }
}
