using System;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson.Serialization.Attributes;

namespace ApiChatOnline.Models.Entities;

public class User
{
    [BsonId]
    [BsonElement("userId")]
    public Guid UserId { get; set; }

    [BsonElement("name")]
    public string Name { get; set; } = string.Empty;

    [BsonElement("lastName")]
    public string LastName { get; set; } = string.Empty;

    [BsonElement("email")]
    public string Email { get; set; } = string.Empty;

    [BsonElement("password")]
    public string Password { get; set; } = string.Empty;

    [BsonElement("conversationsIds")]
    [BsonRepresentation(MongoDB.Bson.BsonType.String)]
    public List<Guid> ConversationsIds { get; set; } = new List<Guid>();

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime LastSeen { get; set; } = DateTime.UtcNow;
}
