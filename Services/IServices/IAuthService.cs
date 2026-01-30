using System;
using ApiChatOnline.Models.Dtos.Auth;

namespace ApiChatOnline.Services.IServices;

public interface IAuthService
{
    Task<ResponseLoginDto> LoginAuth(LogindDto loginDto);
}
