using System;
using riv4lz.Mediator.Dtos.Chat;
using Xunit;

namespace riv4lz.mediatr.test.Dtos;

public class CreateMessageDtoTest
{
    private CreateMessageDto _createMessageDto;

    public CreateMessageDtoTest()
    {
        _createMessageDto = new CreateMessageDto();
    }
    
    [Fact]
    public void CreateMessageDto_CanBeInitialized()
    {
        Assert.NotNull(_createMessageDto);
    }
    
    [Fact]
    public void CreateMessageDto_Id_IsGuid()
    {
        Assert.IsType<Guid>(_createMessageDto.Id);
    }
    
    [Fact]
    public void CreateMessageDto_Id_IsNotEmptyByDefault()
    {
        Assert.Equal(Guid.Empty, _createMessageDto.Id);
    }
    
    [Fact]
    public void CreateMessageDto_Id_IsNotEmptyAfterSet()
    {
        _createMessageDto.Id = Guid.NewGuid();
        Assert.NotEqual(Guid.Empty, _createMessageDto.Id);
    }
    
    [Fact]
    public void CreateMessageDto_Id_CanBeSet()
    {
        _createMessageDto.Id = Guid.NewGuid();
        Assert.NotEqual(Guid.Empty, _createMessageDto.Id);
    }
    
    [Fact]
    public void CreateMessageDto_ChatRoomId_IsGuid()
    {
        Assert.IsType<Guid>(_createMessageDto.ChatRoomId);
    }
    
    [Fact]
    public void CreateMessageDto_ChatRoomId_IsNotEmptyByDefault()
    {
        Assert.Equal(Guid.Empty, _createMessageDto.ChatRoomId);
    }
    
    [Fact]
    public void CreateMessageDto_ChatRoomId_IsNotEmptyAfterSet()
    {
        _createMessageDto.ChatRoomId = Guid.NewGuid();
        Assert.NotEqual(Guid.Empty, _createMessageDto.ChatRoomId);
    }
    
    [Fact]
    public void CreateMessageDto_ChatRoomId_CanBeSet()
    {
        _createMessageDto.ChatRoomId = Guid.NewGuid();
        Assert.NotEqual(Guid.Empty, _createMessageDto.ChatRoomId);
    }
    
    [Fact]
    public void CreateMessageDto_Username_IsString()
    {
        _createMessageDto.Username = "test";
        Assert.IsType<string>(_createMessageDto.Username);
    }
    
    [Fact]
    public void CreateMessageDto_Username_IsNullByDefault()
    {
        Assert.Null(_createMessageDto.Username);
    }
    
    [Fact]
    public void CreateMessageDto_Username_IsNotEmptyAfterSet()
    {
        _createMessageDto.Username = "test";
        Assert.NotEmpty(_createMessageDto.Username);
    }
    
    [Fact]
    public void CreateMessageDto_Username_CanBeSet()
    {
        _createMessageDto.Username = "test";
        Assert.NotEmpty(_createMessageDto.Username);
    }
    
    [Fact]
    public void CreateMessageDto_ProfileImgUrl_IsString()
    {
        _createMessageDto.ProfileImageUrl = "test";
        Assert.IsType<string>(_createMessageDto.ProfileImageUrl);
    }
    
    [Fact]
    public void CreateMessageDto_ProfileImgUrl_IsNullByDefault()
    {
        Assert.Null(_createMessageDto.ProfileImageUrl);
    }
    
    [Fact]
    public void CreateMessageDto_ProfileImgUrl_IsNotEmptyAfterSet()
    {
        _createMessageDto.ProfileImageUrl = "test";
        Assert.NotEmpty(_createMessageDto.ProfileImageUrl);
    }
    
    [Fact]
    public void CreateMessageDto_ProfileImgUrl_CanBeSet()
    {
        _createMessageDto.ProfileImageUrl = "test";
        Assert.NotEmpty(_createMessageDto.ProfileImageUrl);
    }
    
    [Fact]
    public void CreateMessageDto_Text_IsString()
    {
        _createMessageDto.Text = "test";
        Assert.IsType<string>(_createMessageDto.Text);
    }
    
    [Fact]
    public void CreateMessageDto_Text_IsNullByDefault()
    {
        Assert.Null(_createMessageDto.Text);
    }
    
    [Fact]
    public void CreateMessageDto_Text_IsNotEmptyAfterSet()
    {
        _createMessageDto.Text = "test";
        Assert.NotEmpty(_createMessageDto.Text);
    }
    
    [Fact]
    public void CreateMessageDto_Text_CanBeSet()
    {
        _createMessageDto.Text = "test";
        Assert.NotEmpty(_createMessageDto.Text);
    }
}