using Domain.Interface.Service;
using Domain.Model.Auth;
using Microsoft.AspNetCore.Mvc;

namespace DinheirusAPI.Controllers.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] AuthRequest request)
        {
            var authResult = await _authService.ExecuteInternalAuth(request);

            if (authResult.Success)
            {
                return Ok(new { Token = authResult.AccessToken });
            }

            return Unauthorized();
        }
    }
}
