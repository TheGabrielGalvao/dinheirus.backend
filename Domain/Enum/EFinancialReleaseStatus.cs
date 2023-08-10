using System.ComponentModel;

namespace Domain.Enum
{
    public enum EFinancialReleaseStatus
    {
        [Description("Pendente")]
        PENDING = 0,
        [Description("Concluído")]
        COMPLETED = 1,
        [Description("Falhou")]
        FAILED = 2,
        [Description("Cancelado")]
        CANCELLED = 3,
        [Description("Em Processamento")]
        INPROCESS = 4,
        [Description("Reembolsado")]
        REFUNDED = 5,
        [Description("Disputado")]
        DISPUTED = 6,

    }
}
