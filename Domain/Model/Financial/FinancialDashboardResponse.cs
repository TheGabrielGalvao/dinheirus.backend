namespace Domain.Model.Financial
{
    public class FinancialDashboardResponse
    {
        public decimal TotalRevenueCompleted { get; set; }
        public decimal TotalExpenseCompleted { get; set; }
        public decimal TotalRevenuePending { get; set; }
        public decimal TotalExpensePending { get; set; }
        public decimal CurrentBalance { get; set; }
        public decimal ExpectedBalance { get; set; }
    }
}
