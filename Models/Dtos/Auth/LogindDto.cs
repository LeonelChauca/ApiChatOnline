using System;

namespace ApiChatOnline.Models.Dtos.Auth;

public record LogindDto
{
    public string Email { get; init; } = string.Empty;
    public string Password { get; init; } = string.Empty;
}
