using Domain.Entities.Fiancial;

namespace Domain.Interface.Repository.Financial
{
    public interface IFinancialReleaseTypeRepository
    {
        Task<IEnumerable<FinancialReleaseType>> Get();
        Task<FinancialReleaseType> Get(Guid uuid);
        Task<FinancialReleaseType> Create(FinancialReleaseType transactionType);
        Task<FinancialReleaseType> Update(FinancialReleaseType transactionType);
        Task Delete(Guid uuid);
    }
}
