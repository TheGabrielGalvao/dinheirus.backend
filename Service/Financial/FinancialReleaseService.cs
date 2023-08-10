using AutoMapper;
using Domain.Entities.Fiancial;
using Domain.Enum;
using Domain.Interface.Repository.Common;
using Domain.Interface.Repository.Financial;
using Domain.Interface.Service;
using Domain.Model.Financial;

namespace Service.Financial
{
    public class FinancialReleaseService : IFinancialReleaseService
    {
        public readonly IFinancialReleaseRepository _repository;
        public readonly IFinancialReleaseTypeRepository _financialReleaseTypeRepository;
        private readonly IMapper _mapper;
        private readonly IUnityOfWork _uow;
        public FinancialReleaseService(IFinancialReleaseRepository repository, IFinancialReleaseTypeRepository financialReleaseTypeRepository, IMapper mapper, IUnityOfWork uow)
        {
            _repository = repository;
            _financialReleaseTypeRepository = financialReleaseTypeRepository;
            _mapper = mapper;
            _uow = uow;
        }
        public async Task<FinancialReleaseResponse> Create(FinancialReleaseRequest request)
        {
            try
            {
                var financialReleaseType = await _financialReleaseTypeRepository.Get(request.FinancialReleaseTypeUuid);
                var financialRelease = new FinancialRelease
                {
                    Title = request.Title,
                    Value = request.Value,
                    Status = request.Status.GetValueOrDefault(),
                    Operation = financialReleaseType.Operation,
                    FinancialReleaseTypeId = financialReleaseType.Id,
                    FinancialReleaseType = financialReleaseType,
                    UserId = 1
                };



                await _repository.Create(financialRelease);

                _uow.Commit();
                return _mapper.Map<FinancialReleaseResponse>(financialRelease);
            }
            catch (Exception ex)
            {
                _uow.Rollback();
                return null;
            }
        }

        public async Task Delete(Guid uuid)
        {
            try
            {
                await _repository.Delete(uuid);
                _uow.Commit();
            }
            catch
            {
                _uow.Rollback();
            }
        }

        public async Task<IEnumerable<FinancialReleaseResponse>> Get()
        {
            return _mapper.Map<IEnumerable<FinancialReleaseResponse>>(await _repository.Get());
        }

        public async Task<FinancialReleaseResponse> Get(Guid uuid)
        {
            return _mapper.Map<FinancialReleaseResponse>(await _repository.Get(uuid));
        }

        public async Task<FinancialDashboardResponse> GetDashBoardData()
        {
            var financialReleases = await _repository.Get();
            var totalExpenseCompleted = financialReleases.Where(x => x.Operation == Domain.Enum.EFinancialOperation.OUTFLOW && x.Status == EFinancialReleaseStatus.COMPLETED).Sum(x => x.Value);
            var totalRevenueCompleted = financialReleases.Where(x => x.Operation == Domain.Enum.EFinancialOperation.INFLOW && x.Status == EFinancialReleaseStatus.COMPLETED).Sum(x => x.Value);
            
            var totalExpensePending = financialReleases.Where(x => x.Operation == Domain.Enum.EFinancialOperation.OUTFLOW && x.Status == EFinancialReleaseStatus.PENDING).Sum(x => x.Value);
            var totalRevenuePending = financialReleases.Where(x => x.Operation == Domain.Enum.EFinancialOperation.INFLOW && x.Status == EFinancialReleaseStatus.PENDING).Sum(x => x.Value);
            
            var currentBalance = totalRevenueCompleted - totalExpenseCompleted;
            var expectedBalance = totalRevenuePending - totalExpensePending;

            var response = new FinancialDashboardResponse
            {
                TotalExpenseCompleted = totalExpenseCompleted,
                TotalRevenueCompleted = totalRevenueCompleted,
                TotalExpensePending = totalExpensePending,
                TotalRevenuePending = totalRevenuePending,
                CurrentBalance = currentBalance,
                ExpectedBalance = expectedBalance
            };
            
            return response;
        }

        public async Task<FinancialReleaseResponse> Update(Guid uuid, FinancialReleaseRequest request)
        {
            try
            {
                var financialRelease = await _repository.Get(uuid);

                await _repository.Update(financialRelease);
                _uow.Commit();

                return _mapper.Map<FinancialReleaseResponse>(financialRelease);
            }
            catch
            {
                _uow.Rollback();
                return null;
            }
        }
    }
}
