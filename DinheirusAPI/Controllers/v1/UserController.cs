using Domain.Interface.Service;
using Domain.Model.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DinheirusAPI.Controllers.v1
{
    [Authorize]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserService _service;
        public UserController(IUserService service)
        {
            _service = service;
        }
        [HttpGet]
        [Authorize]
        public async Task<IEnumerable<UserResponse>> GetUsers()
        {
            return await _service.Get();
        }

        [HttpGet("{uuid}")]
        [Authorize]
        public async Task<ActionResult<UserResponse>> GetUsers(Guid uuid)
        {
            return await _service.Get(uuid);
        }


        [HttpPost]
        public async Task<ActionResult<UserResponse>> PostUser([FromBody] UserRequest request)
        {
            var newUser = await _service.Create(request);
            return CreatedAtAction(nameof(GetUsers), new { uuid = newUser.Uuid }, newUser);
        }

        [HttpDelete("{uuid}")]
        public async Task<ActionResult> Delete(Guid uuid)
        {
            var userDelete = await _service.Get(uuid);
            if (userDelete == null)
                return NotFound();

            await _service.Delete(uuid);
            return NoContent();
        }

        [HttpPut("{uuid}")]
        public async Task<ActionResult> PutUser(Guid uuid, [FromBody] UserRequest request)
        {
            if (uuid != request.Uuid)
                return BadRequest();

            await _service.Update(uuid, request);

            return NoContent();
        }
    }
}
