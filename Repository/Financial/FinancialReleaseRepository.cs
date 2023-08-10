using Database;
using Domain.Entities.Fiancial;
using Domain.Interface.Repository.Financial;
using Microsoft.EntityFrameworkCore;

namespace Repository.Financial
{
    public class FinancialReleaseRepository: IFinancialReleaseRepository
    {
        public readonly AppDbContext _context;
        public FinancialReleaseRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<FinancialRelease> Create(FinancialRelease transaction)
        {
            _context.FinancialReleases.Add(transaction);

            return transaction;
        }

        public async Task Delete(Guid uuid)
        {
            var transactionDelete = await _context.FinancialReleases.FirstOrDefaultAsync(c => c.Uuid == uuid);
            _context.FinancialReleases.Remove(transactionDelete);
        }

        public async Task<IEnumerable<FinancialRelease>> Get()
        {
            return await _context.FinancialReleases.ToListAsync();
        }

        public async Task<FinancialRelease> Get(Guid uuid)
        {
            var transaction = await _context.FinancialReleases.Include(x => x.FinancialReleaseType).FirstOrDefaultAsync(c => c.Uuid == uuid);
            return transaction;
        }

        public async Task<FinancialRelease> Update(FinancialRelease transaction)
        {
            _context.Entry(transaction).State = EntityState.Modified;
            return transaction;
        }
    }
}
