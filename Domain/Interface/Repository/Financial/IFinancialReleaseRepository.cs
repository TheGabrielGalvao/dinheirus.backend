using Domain.Entities.Fiancial;

namespace Domain.Interface.Repository.Financial
{
    public interface IFinancialReleaseRepository
    {
        Task<IEnumerable<FinancialRelease>> Get();
        Task<FinancialRelease> Get(Guid uuid);
        Task<FinancialRelease> Create(FinancialRelease user);
        Task<FinancialRelease> Update(FinancialRelease user);
        Task Delete(Guid uuid);
    }
}
