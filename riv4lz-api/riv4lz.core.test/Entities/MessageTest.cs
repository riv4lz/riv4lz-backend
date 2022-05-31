using System;
using riv4lz.core.Entities;
using Xunit;

namespace riv4lz.core.test.Entities;

public class MessageTest
{
    private Message _message;

    public MessageTest()
    {
        _message = new Message();
    }
    
    [Fact]
    public void Message_CanBeInitialized()
    {
        Assert.NotNull(_message);
    }
    
    [Fact]
    public void Message_Id_IsGuid()
    {
        Assert.IsType<Guid>(_message.Id);
    }
    
    [Fact]
    public void Message_Id_IsNotEmptyByDefault()
    {
        Assert.Equal(Guid.Empty, _message.Id);
    }
    
    [Fact]
    public void Message_Id_IsNotEmptyAfterSet()
    {
        _message.Id = Guid.NewGuid();
        Assert.NotEqual(Guid.Empty, _message.Id);
    }
    
    [Fact]
    public void Message_Id_CanBeSet()
    {
        var id = Guid.NewGuid();
        _message.Id = id;
        Assert.Equal(id, _message.Id);
    }
    
    [Fact]
    public void Message_UserName_IsString()
    {
        _message.UserName = "test";
        Assert.IsType<string>(_message.UserName);
    }
    
    [Fact]
    public void Message_UserName_IsNullByDefault()
    {
        Assert.Null(_message.UserName);
    }
    
    [Fact]
    public void Message_UserName_CanBeSet()
    {
        var userName = "test";
        _message.UserName = userName;
        Assert.Equal(userName, _message.UserName);
    }
    
    [Fact]
    public void Message_Text_IsString()
    {
        _message.Text = "test";
        Assert.IsType<string>(_message.Text);
    }
    
    [Fact]
    public void Message_Text_IsNullByDefault()
    {
        Assert.Null(_message.Text);
    }
    
    [Fact]
    public void Message_Text_CanBeSet()
    {
        var text = "test";
        _message.Text = text;
        Assert.Equal(text, _message.Text);
    }
    
    [Fact]
    public void Message_ProfileImgUrl_IsString()
    {
        _message.ProfileImageUrl = "test";
        Assert.IsType<string>(_message.ProfileImageUrl);
    }
    
    [Fact]
    public void Message_ProfileImgUrl_IsNullByDefault()
    {
        Assert.Null(_message.ProfileImageUrl);
    }
    
    [Fact]
    public void Message_ProfileImgUrl_CanBeSet()
    {
        var profileImgUrl = "test";
        _message.ProfileImageUrl = profileImgUrl;
        Assert.Equal(profileImgUrl, _message.ProfileImageUrl);
    }
    
    [Fact]
    public void Message_ChatRoomId_IsGuid()
    {
        Assert.IsType<Guid>(_message.ChatRoomId);
    }
    
    [Fact]
    public void Message_ChatRoomId_IsNotEmptyByDefault()
    {
        Assert.Equal(Guid.Empty, _message.ChatRoomId);
    }
    
    [Fact]
    public void Message_ChatRoomId_IsNotEmptyAfterSet()
    {
        _message.ChatRoomId = Guid.NewGuid();
        Assert.NotEqual(Guid.Empty, _message.ChatRoomId);
    }
    
    [Fact]
    public void Message_ChatRoomId_CanBeSet()
    {
        var chatRoomId = Guid.NewGuid();
        _message.ChatRoomId = chatRoomId;
        Assert.Equal(chatRoomId, _message.ChatRoomId);
    }
    
    [Fact]
    public void Message_ChatRoom_IsChatRoom()
    {
        _message.ChatRoom = new ChatRoom();
        Assert.IsType<ChatRoom>(_message.ChatRoom);
    }
    
    [Fact]
    public void Message_ChatRoom_IsNullByDefault()
    {
        Assert.Null(_message.ChatRoom);
    }
    
    [Fact]
    public void Message_ChatRoom_CanBeSet()
    {
        var chatRoom = new ChatRoom();
        _message.ChatRoom = chatRoom;
        Assert.Equal(chatRoom, _message.ChatRoom);
    }
}