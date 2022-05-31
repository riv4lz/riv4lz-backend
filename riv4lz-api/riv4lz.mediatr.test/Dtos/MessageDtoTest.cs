using riv4lz.Mediator.Dtos.Chat;
using Xunit;

namespace riv4lz.mediatr.test.Dtos;

public class MessageDtoTest
{
    private MessageDto _messageDto;

    public MessageDtoTest()
    {
        _messageDto = new MessageDto();
    }
    
    [Fact]
    public void MessageDto_CanBeInitialized()
    {
        Assert.NotNull(_messageDto);
    }
    
    [Fact]
    public void MessageDto_Username_IsString()
    {
        _messageDto.Username = "test";
        Assert.IsType<string>(_messageDto.Username);
    }
    
    [Fact]
    public void MessageDto_Username_CanBeSet()
    {
        _messageDto.Username = "test";
        Assert.Equal("test", _messageDto.Username);
    }
    
    [Fact]
    public void MessageDto_Text_IsString()
    {
        _messageDto.Text = "test";
        Assert.IsType<string>(_messageDto.Text);
    }
    
    [Fact]
    public void MessageDto_Text_CanBeSet()
    {
        _messageDto.Text = "test";
        Assert.Equal("test", _messageDto.Text);
    }
    
    [Fact]
    public void MessageDto_ProfileImgUrl_IsString()
    {
        _messageDto.ProfileImageUrl = "test";
        Assert.IsType<string>(_messageDto.ProfileImageUrl);
    }
    
    [Fact]
    public void MessageDto_ProfileImgUrl_CanBeSet()
    {
        _messageDto.ProfileImageUrl = "test";
        Assert.Equal("test", _messageDto.ProfileImageUrl);
    }
    
}