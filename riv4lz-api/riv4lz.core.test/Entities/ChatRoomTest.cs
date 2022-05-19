using riv4lz.core.Entities;
using Xunit;

namespace riv4lz.core.test.Entities;

public class ChatRoomTest
{
    private ChatRoom _chatRoom;
    
    public ChatRoomTest()
    {
        _chatRoom = new ChatRoom();
    }

    [Fact]
    public void ChatRoom_CanBeInitialized()
    {
        Assert.NotNull(_chatRoom);
    }
}