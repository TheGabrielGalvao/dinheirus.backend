using Domain.Model.Contact;

namespace Domain.Interface.Service
{
    public interface IContactService
    {
        Task<IEnumerable<ContactResponse>> Get();
        Task<ContactResponse> Get(Guid uuid);

        Task<ContactResponse> Create(ContactRequest request);

        Task<ContactResponse> Update(Guid uuid, ContactRequest request);

        Task Delete(Guid uuid);
    }
}

