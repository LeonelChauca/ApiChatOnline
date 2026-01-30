using System;

namespace ApiChatOnline.Services.IServices;

public interface IEncryptService
{
    string Encrypt(string input);

    bool VerifyPassword(string input, string hashedPassword);
}
