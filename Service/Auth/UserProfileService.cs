using AutoMapper;
using Domain.Entities.Auth;
using Domain.Interface.Repository.Auth;
using Domain.Interface.Repository.Common;
using Domain.Interface.Service;
using Domain.Model.Auth;

namespace Service.Auth
{
    public class UserProfileService : IUserProfileService
    {
        public readonly IUserProfileRepository _repository;
        private readonly IMapper _mapper;
        private readonly IUnityOfWork _uow;
        public UserProfileService(IUserProfileRepository repository, IMapper mapper, IUnityOfWork uow)
        {
            _repository = repository;
            _mapper = mapper;
            _uow = uow;
        }
        public async Task<UserProfileResponse> Create(UserProfileRequest request)
        {
            try
            {
                var profile = _mapper.Map<UserProfile>(request);
                await _repository.Create(profile);

                _uow.Commit();
                return _mapper.Map<UserProfileResponse>(profile);
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

        public async Task<IEnumerable<UserProfileResponse>> Get()
        {
            return _mapper.Map<IEnumerable<UserProfileResponse>>(await _repository.Get());
        }

        public async Task<UserProfileResponse> Get(Guid uuid)
        {
            return _mapper.Map<UserProfileResponse>(await _repository.Get(uuid));
        }

        public async Task<UserProfileResponse> Update(Guid uuid, UserProfileRequest request)
        {
            try
            {
                var profile = await _repository.Get(uuid);

                profile.Name = request.Name;
                profile.Description = request.Description;
                profile.Status = request.Status;
                
                await _repository.Update(profile);
                _uow.Commit();

                return _mapper.Map<UserProfileResponse>(profile);
            }
            catch
            {
                _uow.Rollback();
                return null;
            }
        }
    }
}
