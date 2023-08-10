using Domain.Entities.Auth;
using Domain.Model.Auth;

namespace Domain.Interface.Repository.Auth
{
    public interface IUserProfileRepository
    {
        Task<IEnumerable<UserProfile>> Get();
        Task<UserProfile> Get(Guid uuid);
        Task<UserProfile> Create(UserProfile user);

        Task<UserProfile> Update(UserProfile user);

        Task Delete(Guid uuid);
    }
}
