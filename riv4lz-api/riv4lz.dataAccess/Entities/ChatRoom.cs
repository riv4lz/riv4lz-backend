namespace riv4lz.dataAccess.Entities;

public class ChatRoom
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    
    public ICollection<Message> Messages { get; set; }
}