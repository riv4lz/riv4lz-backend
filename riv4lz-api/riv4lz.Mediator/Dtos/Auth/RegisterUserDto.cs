using System.ComponentModel.DataAnnotations;

namespace riv4lz.Mediator.Dtos.Auth;

public class RegisterUserDto
{
    // TODO add validations
    [Required] public string Email { get; set; }
    [Required] public string Password { get; set; }
    [Required] public Guid Id { get; set; }
}