using System.ComponentModel.DataAnnotations;

namespace riv4lz.Mediator.Dtos.Chat;

public class CreateMessageDto
{
    [Required]
    public Guid Id { get; set; }
    [Required]
    public Guid ChatRoomId { get; set; }
    [Required] 
    public Guid UserId { get; set; }
    
    [Required]
    public string Username { get; set; }
    [Required] 
    public string ProfileImageUrl { get; set; }
    [Required]
    public string Text { get; set; }
}