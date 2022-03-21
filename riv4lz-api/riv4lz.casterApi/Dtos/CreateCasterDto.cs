using System.ComponentModel.DataAnnotations;

namespace riv4lz.casterApi.Dtos;

public class CreateCasterDto
{
    [Required] public string Email { get; set; }
    [Required] public string GamerTag { get; set; }
    [Required] public string Password { get; set; }
}