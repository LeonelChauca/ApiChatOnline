using System;
using System.IdentityModel.Tokens.Jwt;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Text;
using ApiChatOnline.config.HandleErrors;
using ApiChatOnline.Models.Dtos.Auth;
using ApiChatOnline.Models.Dtos.User;
using ApiChatOnline.Models.Entities;
using ApiChatOnline.Services.IServices;
using Mapster;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace ApiChatOnline.Services;

public class AuhService : IAuthService
{
    private readonly IUserService _userService;
    private readonly IEncryptService _encryptService;
    private readonly IConfiguration _config;

    public AuhService(
        IUserService userService,
        IEncryptService encryptService,
        IConfiguration config
    )
    {
        _userService = userService;
        _encryptService = encryptService;
        _config = config;
    }

    public async Task<ResponseLoginDto> LoginAuth(LogindDto loginDto)
    {
        var user = await _userService.GetUserByEmail(loginDto.Email);

        if (user == null)
        {
            throw new HandleNotFound("Usuario o contraseña incorrecta");
        }
        var ispassCorrect = _encryptService.VerifyPassword(loginDto.Password, user.Password);

        if (!ispassCorrect)
        {
            throw new HandleNotFound("Usuario o contraseña incorrecta");
        }
        var token = GenerateToken(user);

        var resUser = user.Adapt<ResponseUserDto>();

        return new ResponseLoginDto { User = resUser, AccessToken = token };
    }

    private string GenerateToken(User user)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
            new Claim(ClaimTypes.Email, user.Email),
        };
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]!));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _config["Jwt:Issuer"],
            audience: _config["Jwt:Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddDays(1),
            signingCredentials: creds
        );
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
