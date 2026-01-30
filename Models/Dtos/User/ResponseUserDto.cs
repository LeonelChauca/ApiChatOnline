using System;

namespace ApiChatOnline.Models.Dtos.User;

public record ResponseUserDto
{
    public Guid UserId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}
