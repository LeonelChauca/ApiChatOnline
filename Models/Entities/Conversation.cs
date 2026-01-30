using System;
using MongoDB.Bson.Serialization.Attributes;

namespace ApiChatOnline.Models.Entities;

public class Conversation
{
    [BsonId]
    [BsonRepresentation(MongoDB.Bson.BsonType.String)]
    public Guid ConversationId { get; set; }

    [BsonElement("title")]
    public string Title { get; set; } = string.Empty;

    [BsonElement("isGroup")]
    public bool IsGroup { get; set; }

    [BsonElement("lastActivity")]
    public DateTime LastActivity { get; set; }= DateTime.UtcNow;

    [BsonElement("msgs")]
    public List<Message> Messages { get; set; } = new List<Message>();

    [BsonElement("participantIds")]
    public List<int> ParticipantIds { get; set; } = new List<int>();
}
