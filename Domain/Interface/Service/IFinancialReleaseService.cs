using Domain.Model.Financial;

namespace Domain.Interface.Service
{
    public interface IFinancialReleaseService
    {
        Task<IEnumerable<FinancialReleaseResponse>> Get();
        Task<FinancialReleaseResponse> Get(Guid uuid);

        Task<FinancialReleaseResponse> Create(FinancialReleaseRequest request);

        Task<FinancialReleaseResponse> Update(Guid uuid, FinancialReleaseRequest request);

        Task Delete(Guid uuid);

        Task<FinancialDashboardResponse> GetDashBoardData();

    }
}
