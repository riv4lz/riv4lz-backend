using System.ComponentModel.DataAnnotations;

namespace riv4lz.casterApi.Dtos;

public class LoginCasterDto
{
    [Required]
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }
}