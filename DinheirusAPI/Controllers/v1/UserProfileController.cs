using AutoMapper;
using Domain.Interface.Service;
using Domain.Model.Auth;
using Domain.Model.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DinheirusAPI.Controllers.v1
{
    [Authorize]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUserProfileService _service;
        public UserProfileController(IUserProfileService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        [HttpGet]
        [Authorize]
        public async Task<IEnumerable<UserProfileResponse>> GetUserProfiles()
        {
            return await _service.Get();
        }

        [HttpGet("option-items")]
        [Authorize]
        public async Task<IEnumerable<OptionItemResponse>> GetUserProfilesToSelectOption()
        {
            return _mapper.Map<List<OptionItemResponse>>(await _service.Get());
        }

        [HttpGet("{uuid}")]
        [Authorize]
        public async Task<ActionResult<UserProfileResponse>> GetUserProfiles(Guid uuid)
        {
            return await _service.Get(uuid);
        }


        [HttpPost]
        public async Task<ActionResult<UserProfileResponse>> PostUserProfile([FromBody] UserProfileRequest request)
        {
            var newUserProfile = await _service.Create(request);
            return CreatedAtAction(nameof(GetUserProfiles), new { uuid = newUserProfile.Uuid }, newUserProfile);
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
        public async Task<ActionResult> PutUserProfile(Guid uuid, [FromBody] UserProfileRequest request)
        {
            if (uuid != request.Uuid)
                return BadRequest();

            await _service.Update(uuid, request);

            return NoContent();
        }
    }
}
