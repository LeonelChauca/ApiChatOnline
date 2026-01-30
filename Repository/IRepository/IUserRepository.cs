using System;
using ApiChatOnline.Models.Entities;

namespace ApiChatOnline.Repository.IRepository;

public interface IUserRepository
{
    User CreateUser(User user);

    Task<IReadOnlyCollection<User>> GetUsers();

    Task<User?> GetUserByEmail(string email);

    Task<bool> SaveChangesAsync();
}
