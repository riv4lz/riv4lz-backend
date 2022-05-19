using System;
using System.Collections.Generic;
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
    
    [Fact]
    public void ChatRoom_CanBeInitializedWithId()
    {
        var id = Guid.NewGuid();
        var chatRoom = new ChatRoom(id);
        Assert.Equal(id, chatRoom.Id);
    }

    [Fact]
    public void ChatRoom_SettingName_SetsName()
    {
        _chatRoom.Name = "Test";
        Assert.Equal("Test", _chatRoom.Name);
    }
    
    [Fact]
    public void ChatRoom_SettingId_SetsId()
    {
        var id = new Guid();
        _chatRoom.Id = id;
        Assert.Equal(id, _chatRoom.Id);
    }
    
    [Fact]
    public void ChatRoom_Name_IsNullByDefault()
    {
        Assert.Null(_chatRoom.Name);
    }
    
    [Fact]
    public void ChatRoom_Name_IsString()
    {
        _chatRoom.Name = "Test";
        Assert.IsType<string>(_chatRoom.Name);
    }
    
    [Fact]
    public void ChatRoom_Id_IsGuidByDefault()
    {
        Assert.IsType<Guid>(_chatRoom.Id);
    }
    
    [Fact]
    public void ChatRoom_AddingMessage_AddsMessage()
    {
        var message = new Message();
        _chatRoom.Messages = new List<Message>();
        _chatRoom.Messages.Add(message);
        Assert.Contains(message, _chatRoom.Messages);
    }
    
    [Fact]
    public void ChatRoom_RemovingMessage_RemovesMessage()
    {
        var message = new Message();
        _chatRoom.Messages = new List<Message>();
        _chatRoom.Messages.Add(message);
        _chatRoom.Messages.Remove(message);
        Assert.DoesNotContain(message, _chatRoom.Messages);
    }
    
}