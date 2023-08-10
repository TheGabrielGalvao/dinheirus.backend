using Domain.Entities;
using Domain.Entities.Auth;
using Domain.Model.Auth;

namespace Domain.Interface.Repository.Auth
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> Get();
        Task<User> Get(Guid uuid);

        Task<User> Get(AuthRequest request);

        Task<User> Create(User user);

        Task<User> Update(User user);

        Task Delete(Guid uuid);
    }
}
