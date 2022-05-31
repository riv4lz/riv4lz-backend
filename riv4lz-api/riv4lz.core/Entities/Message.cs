namespace riv4lz.core.Entities;

public class Message
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string UserName { get; set; }
    public string Text { get; set; }
    public string ProfileImageUrl { get; set; }
    public Guid ChatRoomId { get; set; }
    public ChatRoom ChatRoom { get; set; }
}