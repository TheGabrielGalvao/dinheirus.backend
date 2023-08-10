using AutoMapper;
using Domain.Entities;
using Domain.Interface.Repository;
using Domain.Interface.Repository.Common;
using Domain.Interface.Service;
using Domain.Model.Contact;

namespace Service
{
    public class ContactService : IContactService
    {
        public readonly IContactRepository _repository ;
        private readonly IMapper _mapper;
        private readonly IUnityOfWork _uow ;
        public ContactService(IContactRepository repository, IMapper mapper, IUnityOfWork uow)
        {
            _repository = repository;
            _mapper = mapper;
            _uow = uow;
        }
        public async Task<ContactResponse> Create(ContactRequest request)
        {
            try
            {
                var contact = _mapper.Map<Contact>(request);
                await _repository.Create(contact);

                _uow.Commit();
                return _mapper.Map<ContactResponse>(contact);
            }
            catch (Exception ex) {
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
            catch {
                _uow.Rollback();
            }
        }

        public async Task<IEnumerable<ContactResponse>> Get()
        {
            return _mapper.Map<IEnumerable<ContactResponse>>(await _repository.Get());
        }

        public async Task<ContactResponse> Get(Guid uuid)
        {
            return _mapper.Map<ContactResponse>(await _repository.Get(uuid));
        }

        public async Task<ContactResponse> Update(Guid uuid, ContactRequest request)
        {
            try
            {
                var contact = await _repository.Get(uuid);

                contact.FullName = request.FullName;
                contact.Email = request.Email;
                contact.CpfCnpj = request.CpfCnpj;
                contact.Phone = request.Phone;
                contact.SecondaryPhone = request.SecondaryPhone;
                contact.DocumentType = request.DocumentType;
                contact.Status = request.Status;
                contact.SurName = request.SurName;

                await _repository.Update(contact);
                _uow.Commit();

                return _mapper.Map<ContactResponse>(contact);
            }
            catch { 
                _uow.Rollback();
                return null;
            }
        }
    }
}
