using System.ComponentModel.DataAnnotations;

namespace riv4lz.Mediator.Dtos.Auth;

public class UpdateEmailDto
{
    [Required]
    public Guid UserId { get; set; }
    [Required]
    [EmailAddress]
    public string Email { get; set; }
}