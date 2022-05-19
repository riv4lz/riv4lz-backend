using EntityFrameworkCore.Testing.Moq;
using Microsoft.EntityFrameworkCore;
using riv4lz.core.Entities;
using Xunit;

namespace riv4lz.dataAccess.test;

public class ChatContextTest
{
    private ChatContext _chatContext;

    public ChatContextTest()
    {
        _chatContext = Create.MockedDbContextFor<ChatContext>();
    }

    [Fact]
    public void ChatContext_WithDbContextOptions_IsAvailable()
    {
        Assert.NotNull(_chatContext);
    }
    
    [Fact]
    public void ChatContext_IsAssignableFromDbContext()
    {
        Assert.IsAssignableFrom<DbContext>(_chatContext);
    }

    [Fact]
    public void ChatContext_DbSets_MustHaveDbSetWithTypeMessage()
    {
        Assert.True(_chatContext.Messages is DbSet<Message>);
    }
    
    [Fact]
    public void ChatContext_DbSets_MustHaveDbSetWithTypeChatRooms()
    {
        Assert.True(_chatContext.ChatRooms is DbSet<ChatRoom>);
    }
    
}