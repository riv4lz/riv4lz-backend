namespace riv4lz.Mediator.Dtos.Chat;

public class MessageDto
{
    public Guid UserId { get; set; }
    public string Username { get; set; }
    public string ProfileImageUrl { get; set; }
    public string Text { get; set; }
}