using System.ComponentModel.DataAnnotations;

namespace riv4lz.Mediator.Dtos.Auth;

public class RegisterUserDto
{
    [Required] 
    public Guid Id { get; set; }
    [Required] 
    [EmailAddress]
    public string Email { get; set; }
    [Required] 
    public string Password { get; set; }
}