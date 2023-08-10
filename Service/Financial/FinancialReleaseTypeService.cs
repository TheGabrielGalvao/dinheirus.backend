using AutoMapper;
using Domain.Entities.Fiancial;
using Domain.Interface.Repository.Common;
using Domain.Interface.Repository.Financial;
using Domain.Interface.Service;
using Domain.Model.Financial;

namespace Service.Financial
{
    public class FinancialReleaseTypeService : IFinancialReleaseTypeService
    {
        public readonly IFinancialReleaseTypeRepository _repository;
        private readonly IMapper _mapper;
        private readonly IUnityOfWork _uow;
        public FinancialReleaseTypeService(IFinancialReleaseTypeRepository repository, IMapper mapper, IUnityOfWork uow)
        {
            _repository = repository;
            _mapper = mapper;
            _uow = uow;
        }
        public async Task<FinancialReleaseTypeResponse> Create(FinancialReleaseTypeRequest request)
        {
            try
            {
                var financialRelease = new FinancialReleaseType
                {
                    Name = request.Name,
                    Description = request.Description,
                    Operation = request.Operation,
                    Status = request.Status,
                    UserId = 1
                };



                await _repository.Create(financialRelease);

                _uow.Commit();
                return _mapper.Map<FinancialReleaseTypeResponse>(financialRelease);
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

        public async Task<IEnumerable<FinancialReleaseTypeResponse>> Get()
        {
            return _mapper.Map<IEnumerable<FinancialReleaseTypeResponse>>(await _repository.Get());
        }

        public async Task<FinancialReleaseTypeResponse> Get(Guid uuid)
        {
            return _mapper.Map<FinancialReleaseTypeResponse>(await _repository.Get(uuid));
        }


        public async Task<FinancialReleaseTypeResponse> Update(Guid uuid, FinancialReleaseTypeRequest request)
        {
            try
            {
                var financialReleaseType = await _repository.Get(uuid);

                await _repository.Update(financialReleaseType);
                _uow.Commit();

                return _mapper.Map<FinancialReleaseTypeResponse>(financialReleaseType);
            }
            catch
            {
                _uow.Rollback();
                return null;
            }
        }
    }
}
