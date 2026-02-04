using ApiChatOnline.Extensions;
using ApiChatOnline.Models.Dtos.Auth;
using ApiChatOnline.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiChatOnline.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LogindDto loginDto)
        {
            var loginOk = await _authService.LoginAuth(loginDto);

            return loginOk.ToOkResponse("Ingreso Correcto");
        }
    }
}
