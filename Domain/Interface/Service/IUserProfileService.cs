using Domain.Model.Auth;

namespace Domain.Interface.Service
{
    public interface IUserProfileService
    {
        Task<IEnumerable<UserProfileResponse>> Get();
        Task<UserProfileResponse> Get(Guid uuid);

        Task<UserProfileResponse> Create(UserProfileRequest request);

        Task<UserProfileResponse> Update(Guid uuid, UserProfileRequest request);

        Task Delete(Guid uuid);
    }
}
