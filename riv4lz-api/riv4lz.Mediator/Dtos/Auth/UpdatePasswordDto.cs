using System.ComponentModel.DataAnnotations;

namespace riv4lz.Mediator.Dtos.Auth;

public class UpdatePasswordDto
{
    [Required]
    public Guid UserId { get; set; }
    [Required]
    public string OldPassword { get; set; }
    [Required]
    public string NewPassword { get; set; }
}