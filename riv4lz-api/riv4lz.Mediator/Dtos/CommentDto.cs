namespace riv4lz.Mediator.Dtos;

public class CommentDto
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public string Body { get; set; }
    public string UserName { get; set; }    
}