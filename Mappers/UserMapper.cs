using System;
using ApiChatOnline.Models.Dtos.User;
using ApiChatOnline.Models.Entities;
using Mapster;

namespace ApiChatOnline.Mappers;

public class UserMapper : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CreateUserDto, User>();
        config.NewConfig<User, ResponseUserDto>();
    }
}
