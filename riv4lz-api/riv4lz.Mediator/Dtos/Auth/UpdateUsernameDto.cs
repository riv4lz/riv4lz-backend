using System.ComponentModel.DataAnnotations;

namespace riv4lz.Mediator.Dtos.Auth;

public class UpdateUsernameDto
{
    [Required]
    public Guid UserId { get; set; }
    [Required]
    public string Username { get; set;}
}