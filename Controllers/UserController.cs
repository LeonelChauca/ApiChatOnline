using ApiChatOnline.Extensions;
using ApiChatOnline.Models.Dtos.User;
using ApiChatOnline.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiChatOnline.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserDto userDto)
        {
            var userCreated = await _userService.CreateUserAsync(userDto);
            return userCreated.ToCreatedResponse(
                "Usuario creado correctamente",
                nameof(GetUsers),
                new { idUser = userCreated.UserId }
            );
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _userService.GetUsersAsync();
            return users.ToOkResponse("Lista de usuarios obtenida correctamente");
        }
    }
}
