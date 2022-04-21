namespace riv4lz.domain;

public class Comment
{
    public int Id { get; set; }
    public string Body { get; set; }
    public string UserName { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}