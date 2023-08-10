using Domain.Interface.Service;
using Domain.Model.Contact;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DinheirusAPI.Controllers.v1
{
    [Authorize]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {

        private readonly IContactService _service;
        public ContactController(IContactService service)
        {
            _service = service;
        }
        [HttpGet]
        [Authorize]
        public async Task<IEnumerable<ContactResponse>> GetContacts()
        {
            return await _service.Get();
        }

        [HttpGet("{uuid}")]
        [Authorize]
        public async Task<ActionResult<ContactResponse>> GetContacts(Guid uuid)
        {
            return await _service.Get(uuid);
        }


        [HttpPost]
        public async Task<ActionResult<ContactResponse>> PostContact([FromBody] ContactRequest contact)
        {
            var newContact = await _service.Create(contact);
            return CreatedAtAction(nameof(GetContacts), new { uuid = newContact.Uuid }, newContact);
        }

        [HttpDelete("{uuid}")]
        public async Task<ActionResult> Delete(Guid uuid)
        {
            var contactDelete = await _service.Get(uuid);
            if (contactDelete == null)
                return NotFound();

            await _service.Delete(uuid);
            return NoContent();
        }

        [HttpPut("{uuid}")]
        public async Task<ActionResult> PutContact(Guid uuid, [FromBody] ContactRequest contact)
        {
            if (uuid != contact.Uuid)
                return BadRequest();

            await _service.Update(uuid, contact);

            return NoContent();
        }
    }
}
