using System.ComponentModel.DataAnnotations;

namespace riv4lz.Mediator.Dtos;

public class RegisterUserDto
{
    // TODO add validations
    [Required] public string Email { get; set; }
    [Required] public string Password { get; set; }
}