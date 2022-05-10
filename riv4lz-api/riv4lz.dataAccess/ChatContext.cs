using Microsoft.EntityFrameworkCore;
using riv4lz.core.Entities;

namespace riv4lz.dataAccess;

public class ChatContext: DbContext
{
    public ChatContext(DbContextOptions<ChatContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<Message>()
            .HasOne<ChatRoom>(m => m.ChatRoom)
            .WithMany(c => c.Messages)
            .HasForeignKey(m => m.ChatRoomId);
    }

    public virtual DbSet<ChatRoom> ChatRooms { get; set; }
    public virtual DbSet<Message> Messages { get; set; }
}