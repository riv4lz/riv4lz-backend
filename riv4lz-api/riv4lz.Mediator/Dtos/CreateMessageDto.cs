namespace riv4lz.Mediator.Dtos;

public class CreateMessageDto
{
    public Guid Id { get; set; }
    public Guid ChatRoomId { get; set; }
    public string Username { get; set; }
    public string Text { get; set; }
    public string ChatRoomName { get; set; }
}