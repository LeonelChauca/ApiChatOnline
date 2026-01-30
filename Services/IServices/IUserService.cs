using ApiChatOnline.Models.Dtos.User;
using ApiChatOnline.Models.Entities;

namespace ApiChatOnline.Services.IServices;

public interface IUserService
{
    Task<ResponseUserDto> CreateUserAsync(CreateUserDto createUserDto);
    Task<IReadOnlyCollection<ResponseUserDto>> GetUsersAsync();
    Task<User?> GetUserByEmail(string email);
}
