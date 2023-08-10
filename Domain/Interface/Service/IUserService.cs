using Domain.Model.Auth;

namespace Domain.Interface.Service
{
    public interface IUserService
    {
        Task<IEnumerable<UserResponse>> Get();
        Task<UserResponse> Get(Guid uuid);

        Task<UserResponse> Create(UserRequest request);

        Task<UserResponse> Update(Guid uuid, UserRequest request);

        Task Delete(Guid uuid);
    }
}
