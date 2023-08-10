using System.ComponentModel;

namespace Domain.Enum
{
    public enum EFinancialOperation
    {
        [Description("Entrada")]
        INFLOW = 0,

        [Description("Saída")]
        OUTFLOW = 1,

    }
}
