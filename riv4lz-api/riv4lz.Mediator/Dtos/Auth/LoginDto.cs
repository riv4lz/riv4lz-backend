using System.ComponentModel.DataAnnotations;

namespace riv4lz.Mediator.Dtos.Auth;

public class LoginDto
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }
}