using System;
using ApiChatOnline.Data;
using ApiChatOnline.Models.Entities;
using ApiChatOnline.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace ApiChatOnline.Repository;

public class UserRepository : IUserRepository
{
    private readonly MongoDbContext _db;

    public UserRepository(MongoDbContext db)
    {
        _db = db;
    }

    public User CreateUser(User user)
    {
        _db.User.Add(user);
        return user;
    }

    public async Task<IReadOnlyCollection<User>> GetUsers()
    {
        var users = await _db.User.AsNoTracking().ToListAsync();
        return users;
    }

    public async Task<User?> GetUserByEmail(string email)
    {
        return await _db.User.AsNoTracking().FirstOrDefaultAsync(u => u.Email == email);
    }

    public async Task<bool> SaveChangesAsync()
    {
        return await _db.SaveChangesAsync() > 0;
    }
}
