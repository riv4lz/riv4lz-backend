namespace riv4lz.core.Entities;

public class ChatRoom
{
    public ChatRoom(Guid id)
    {
        Id = id;
    }

    public ChatRoom()
    {
    }

    public Guid Id { get; set; }
    public string Name { get; set; }
    public ICollection<Message> Messages { get; set; }
}