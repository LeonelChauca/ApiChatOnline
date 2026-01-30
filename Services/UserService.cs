using ApiChatOnline.Models.Dtos.User;
using ApiChatOnline.Models.Entities;
using ApiChatOnline.Repository.IRepository;
using ApiChatOnline.Services.IServices;
using Mapster;

namespace ApiChatOnline.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IEncryptService _EncryptService;

    public UserService(IUserRepository userRepository, IEncryptService encryptService)
    {
        _userRepository = userRepository;
        _EncryptService = encryptService;
    }

    public async Task<ResponseUserDto> CreateUserAsync(CreateUserDto userDto)
    {
        var user = userDto.Adapt<User>();

        user.Password = _EncryptService.Encrypt(user.Password);

        var userCreated = _userRepository.CreateUser(user);

        await _userRepository.SaveChangesAsync();

        return userCreated.Adapt<ResponseUserDto>();
    }

    public async Task<User?> GetUserByEmail(string email)
    {
        var user = await _userRepository.GetUserByEmail(email);
        return user;
    }

    public async Task<IReadOnlyCollection<ResponseUserDto>> GetUsersAsync()
    {
        var users = await _userRepository.GetUsers();
        return users.Adapt<IReadOnlyCollection<ResponseUserDto>>();
    }
}
