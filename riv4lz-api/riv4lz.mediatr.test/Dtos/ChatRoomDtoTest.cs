using System;
using riv4lz.Mediator.Dtos.Chat;
using Xunit;

namespace riv4lz.mediatr.test.Dtos;

public class ChatRoomDtoTest
{
    private ChatRoomDto _chatRoomDto;

    public ChatRoomDtoTest()
    {
        _chatRoomDto = new ChatRoomDto();
    }
    
    [Fact]
    public void ChatRoomDto_CanBeInitialized()
    {
        Assert.NotNull(_chatRoomDto);
    }
    
    [Fact]
    public void ChatRoomDto_Id_IsGuid()
    {
        Assert.IsType<Guid>(_chatRoomDto.Id);
    }
    
    [Fact]
    public void ChatRoomDto_Id_IsNotEmptyByDefault()
    {
        Assert.Equal(Guid.Empty, _chatRoomDto.Id);
    }
    
    [Fact]
    public void ChatRoomDto_Id_CanBeSet()
    {
        var id = Guid.NewGuid();
        _chatRoomDto.Id = id;
        Assert.Equal(id, _chatRoomDto.Id);
    }
    
    [Fact]
    public void ChatRoomDto_Name_IsString()
    {
        _chatRoomDto.Name = "Test";
        Assert.IsType<string>(_chatRoomDto.Name);
    }
    
    [Fact]
    public void ChatRoomDto_Name_IsNullByDefault()
    {
        Assert.Null(_chatRoomDto.Name);
    }
    
    [Fact]
    public void ChatRoomDto_Name_CanBeSet()
    {
        var name = "Test";
        _chatRoomDto.Name = name;
        Assert.Equal(name, _chatRoomDto.Name);
    }
    
}