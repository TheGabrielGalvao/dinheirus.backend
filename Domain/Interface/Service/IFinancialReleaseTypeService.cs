using Domain.Model.Financial;

namespace Domain.Interface.Service
{
    public interface IFinancialReleaseTypeService
    {
        Task<IEnumerable<FinancialReleaseTypeResponse>> Get();
        Task<FinancialReleaseTypeResponse> Get(Guid uuid);

        Task<FinancialReleaseTypeResponse> Create(FinancialReleaseTypeRequest request);

        Task<FinancialReleaseTypeResponse> Update(Guid uuid, FinancialReleaseTypeRequest request);

        Task Delete(Guid uuid);
    }
}
