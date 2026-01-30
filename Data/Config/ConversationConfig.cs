using ApiChatOnline.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MongoDB.EntityFrameworkCore.Extensions;

namespace ApiChatOnline.Data.Config;

public class ConversationConfig : IEntityTypeConfiguration<Conversation>
{
    public void Configure(EntityTypeBuilder<Conversation> builder)
    {
        builder.ToCollection("conversations");
        builder.HasKey(c => c.ConversationId);
        builder.OwnsMany(c => c.Messages);
    }
}
