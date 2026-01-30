using System;
using ApiChatOnline.Data.Config;
using ApiChatOnline.Models.Entities;
using Microsoft.EntityFrameworkCore;
namespace ApiChatOnline.Data;

public class MongoDbContext : DbContext {

    public DbSet<Message> Messages { get; init; }
    public DbSet<Conversation> Conversation { get; init; }
    public DbSet<User> User { get; init; }
    public MongoDbContext(DbContextOptions options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new UserConfig());
        modelBuilder.ApplyConfiguration(new ConversationConfig());
    }
}