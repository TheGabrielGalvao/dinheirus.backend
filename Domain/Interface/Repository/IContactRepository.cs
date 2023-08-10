using Domain.Entities;

namespace Domain.Interface.Repository
{
    public interface IContactRepository
    {
        Task<IEnumerable<Contact>> Get();
        Task<Contact> Get(Guid uuid);

        Task<Contact> Create(Contact Contact);

        Task<Contact> Update(Contact Contact);

        Task Delete(Guid uuid);
    }
}
