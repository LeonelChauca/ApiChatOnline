using System;
using MongoDB.Bson.Serialization.Attributes;

namespace ApiChatOnline.Models.Entities;

public class Message
{
    [BsonElement("_id")]
    public Guid MessageId { get; set; }
    
    [BsonElement("userId")]
    public int UserId { get; set; }
    [BsonElement("senderName")]
    public string SenderName { get; set; } = string.Empty;
    [BsonElement("content")]
    public string Content { get; set; }= string.Empty;
    [BsonElement("sentAt")]
    public DateTime SentAt { get; set; }= DateTime.UtcNow;
    [BsonElement("isRead")]
    public bool IsRead { get; set; }

}
