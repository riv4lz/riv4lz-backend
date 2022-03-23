using System.ComponentModel.DataAnnotations;

namespace riv4lz.casterApi.Dtos;

public class RegisterCasterDto
{
    // TODO add validations
    [Required] public string Email { get; set; }
    [Required] public string GamerTag { get; set; }
    [Required] public string Password { get; set; }
}