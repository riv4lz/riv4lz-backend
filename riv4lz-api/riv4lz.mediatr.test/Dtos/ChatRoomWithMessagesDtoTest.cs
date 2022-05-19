using System;
using System.Collections.Generic;
using riv4lz.Mediator.Dtos.Chat;
using Xunit;

namespace riv4lz.mediatr.test.Dtos;

public class ChatRoomWithMessagesDtoTest
{
    private ChatRoomWithMessagesDto _chatRoomWithMessagesDto;

    public ChatRoomWithMessagesDtoTest()
    {
        _chatRoomWithMessagesDto = new ChatRoomWithMessagesDto();
    }
    
    [Fact]
    private void ChatRoomWithMessagesDto_CanBeInitialized()
    {
        Assert.NotNull(_chatRoomWithMessagesDto);
    }
    
    [Fact]
    private void ChatRoomWithMessagesDto_Id_IsGuid()
    {
        Assert.IsType<Guid>(_chatRoomWithMessagesDto.Id);
    }
    
    [Fact]
    private void ChatRoomWithMessagesDto_Id_IsNotEmptyByDefault()
    {
        Assert.Equal(Guid.Empty, _chatRoomWithMessagesDto.Id);
    }
    
    [Fact]
    public void ChatRoomWithMessagesDto_Id_CanBeSet()
    {
        var id = Guid.NewGuid();
        _chatRoomWithMessagesDto.Id = id;
        Assert.Equal(id, _chatRoomWithMessagesDto.Id);
    }
    
    [Fact]
    private void ChatRoomWithMessagesDto_Name_IsString()
    {
        _chatRoomWithMessagesDto.Name = "Test";
        Assert.IsType<string>(_chatRoomWithMessagesDto.Name);
    }
    
    [Fact]
    private void ChatRoomWithMessagesDto_Name_IsNullByDefault()
    {
        Assert.Null(_chatRoomWithMessagesDto.Name);
    }
    
    [Fact]
    public void ChatRoomWithMessagesDto_Name_CanBeSet()
    {
        var name = "Test";
        _chatRoomWithMessagesDto.Name = name;
        Assert.Equal(name, _chatRoomWithMessagesDto.Name);
    }
    
    [Fact]
    private void ChatRoomWithMessagesDto_Messages_IsListOfChatMessageDto()
    {
        _chatRoomWithMessagesDto.Messages = new List<MessageDto>();
        Assert.IsType<List<MessageDto>>(_chatRoomWithMessagesDto.Messages);
    }
    
    [Fact]
    private void ChatRoomWithMessagesDto_Messages_IsNullByDefault()
    {
        Assert.Null(_chatRoomWithMessagesDto.Messages);
    }
    
    [Fact]
    public void ChatRoomWithMessagesDto_Messages_CanBeSet()
    {
        var messages = new List<MessageDto>();
        _chatRoomWithMessagesDto.Messages = messages;
        Assert.Equal(messages, _chatRoomWithMessagesDto.Messages);
    }
    
    [Fact]
    private void ChatRoomWithMessagesDto_Messages_CanAddMessage()
    {
        _chatRoomWithMessagesDto.Messages = new List<MessageDto>();
        var message = new MessageDto();
        _chatRoomWithMessagesDto.Messages.Add(message);
        Assert.Equal(message, _chatRoomWithMessagesDto.Messages[0]);
    }
    
    [Fact]
    private void ChatRoomWithMessagesDto_Messages_CanAddMultipleMessages()
    {
        _chatRoomWithMessagesDto.Messages = new List<MessageDto>();
        var message1 = new MessageDto();
        var message2 = new MessageDto();
        _chatRoomWithMessagesDto.Messages.Add(message1);
        _chatRoomWithMessagesDto.Messages.Add(message2);
        Assert.Equal(message1, _chatRoomWithMessagesDto.Messages[0]);
        Assert.Equal(message2, _chatRoomWithMessagesDto.Messages[1]);
    }
    
    [Fact]
    private void ChatRoomWithMessagesDto_Messages_CanRemoveMessage()
    {
        _chatRoomWithMessagesDto.Messages = new List<MessageDto>();
        var message = new MessageDto();
        _chatRoomWithMessagesDto.Messages.Add(message);
        _chatRoomWithMessagesDto.Messages.Remove(message);
        Assert.Empty(_chatRoomWithMessagesDto.Messages);
    }
    
    [Fact]
    private void ChatRoomWithMessagesDto_Messages_CanRemoveMultipleMessages()
    {
        _chatRoomWithMessagesDto.Messages = new List<MessageDto>();
        var message1 = new MessageDto();
        var message2 = new MessageDto();
        _chatRoomWithMessagesDto.Messages.Add(message1);
        _chatRoomWithMessagesDto.Messages.Add(message2);
        _chatRoomWithMessagesDto.Messages.Remove(message1);
        _chatRoomWithMessagesDto.Messages.Remove(message2);
        Assert.Empty(_chatRoomWithMessagesDto.Messages);
    }
    
    [Fact]
    private void ChatRoomWithMessagesDto_Messages_CanClearMessages()
    {
        _chatRoomWithMessagesDto.Messages = new List<MessageDto>();
        var message1 = new MessageDto();
        var message2 = new MessageDto();
        _chatRoomWithMessagesDto.Messages.Add(message1);
        _chatRoomWithMessagesDto.Messages.Add(message2);
        _chatRoomWithMessagesDto.Messages.Clear();
        Assert.Empty(_chatRoomWithMessagesDto.Messages);
    }
    
    [Fact]
    private void ChatRoomWithMessagesDto_Messages_CanCheckIfContainsMessage()
    {
        _chatRoomWithMessagesDto.Messages = new List<MessageDto>();
        var message1 = new MessageDto();
        var message2 = new MessageDto();
        _chatRoomWithMessagesDto.Messages.Add(message1);
        _chatRoomWithMessagesDto.Messages.Add(message2);
        Assert.Contains(message1, _chatRoomWithMessagesDto.Messages);
        Assert.Contains(message2, _chatRoomWithMessagesDto.Messages);
    }
    
    [Fact]
    private void ChatRoomWithMessagesDto_Messages_CanCheckIfDoesNotContainMessage()
    {
        _chatRoomWithMessagesDto.Messages = new List<MessageDto>();
        var message1 = new MessageDto();
        var message2 = new MessageDto();
        _chatRoomWithMessagesDto.Messages.Add(message1);
        _chatRoomWithMessagesDto.Messages.Add(message2);
        Assert.DoesNotContain(new MessageDto(), _chatRoomWithMessagesDto.Messages);
    }
    
    [Fact]
    private void ChatRoomWithMessagesDto_Messages_CanGetIndexOfMessage()
    {
        _chatRoomWithMessagesDto.Messages = new List<MessageDto>();
        var message1 = new MessageDto();
        var message2 = new MessageDto();
        _chatRoomWithMessagesDto.Messages.Add(message1);
        _chatRoomWithMessagesDto.Messages.Add(message2);
        Assert.Equal(0, _chatRoomWithMessagesDto.Messages.IndexOf(message1));
        Assert.Equal(1, _chatRoomWithMessagesDto.Messages.IndexOf(message2));
    }
    
    
}