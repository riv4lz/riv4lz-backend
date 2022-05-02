namespace riv4lz.Mediator.Dtos;

public class ChatRoomDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public List<MessageDto> Messages { get; set; }
}