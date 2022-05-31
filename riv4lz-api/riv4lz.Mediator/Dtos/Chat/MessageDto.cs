namespace riv4lz.Mediator.Dtos.Chat;

public class MessageDto
{
    public Guid UserId { get; set; }
    public string Username { get; set; }
    public string ProfileImgUrl { get; set; }
    public string Text { get; set; }
}