namespace riv4lz.Mediator.Dtos.Chat;

public class ChatRoomWithMessagesDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public List<MessageDto> Messages { get; set; }
}