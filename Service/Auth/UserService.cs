using AutoMapper;
using Domain.Entities.Auth;
using Domain.Interface.Repository.Auth;
using Domain.Interface.Repository.Common;
using Domain.Interface.Service;
using Domain.Model.Auth;

namespace Service.Auth
{
    public class UserService : IUserService
    {
        public readonly IUserRepository _repository;
        public readonly IUserProfileRepository _profileRepository;
        private readonly IMapper _mapper;
        private readonly IUnityOfWork _uow;
        public UserService(IUserRepository repository, IMapper mapper, IUnityOfWork uow, IUserProfileRepository profileRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _uow = uow;
            _profileRepository = profileRepository;
        }
        public async Task<UserResponse> Create(UserRequest request)
        {
            try
            {
                var profile = await _profileRepository.Get(request.ProfileUuid.Value);
                var user = _mapper.Map<User>(request);
                
                user.ProfileId = profile.Id;
                user.Profile = profile;
                await _repository.Create(user);

                _uow.Commit();
                return _mapper.Map<UserResponse>(user);
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

        public async Task<IEnumerable<UserResponse>> Get()
        {
            return _mapper.Map<IEnumerable<UserResponse>>(await _repository.Get());
        }

        public async Task<UserResponse> Get(Guid uuid)
        {
            var teste = _mapper.Map<UserResponse>(await _repository.Get(uuid));
            return _mapper.Map<UserResponse>(await _repository.Get(uuid));
        }

        public async Task<UserResponse> Update(Guid uuid, UserRequest request)
        {
            try
            {
                var user = await _repository.Get(uuid);
                var profile = await _profileRepository.Get(request.ProfileUuid.Value);

                user.Name = request.Name;
                user.Email = request.Email;
                user.Password = request.Password;
                user.Profile = profile;
                user.Status = request.Status;
                
                await _repository.Update(user);
                _uow.Commit();

                return _mapper.Map<UserResponse>(user);
            }
            catch
            {
                _uow.Rollback();
                return null;
            }
        }
    }
}
