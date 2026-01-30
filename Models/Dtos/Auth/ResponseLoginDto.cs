using System;
using ApiChatOnline.Models.Dtos.User;

namespace ApiChatOnline.Models.Dtos.Auth;

public record ResponseLoginDto
{
    public ResponseUserDto User { get; init; } = new ResponseUserDto();
    public string AccessToken { get; init; } = string.Empty;
}
