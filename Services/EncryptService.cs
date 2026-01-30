using System;
using ApiChatOnline.Services.IServices;
using BCrypt.Net;

namespace ApiChatOnline.Services;

public class EncryptService : IEncryptService
{
    public string Encrypt(string input)
    {
        var encrypted = BCrypt.Net.BCrypt.HashPassword(input);
        return encrypted;
    }

    public bool VerifyPassword(string input, string hashedPassword)
    {
        return BCrypt.Net.BCrypt.Verify(input, hashedPassword);
    }
}
