namespace riv4lz.Mediator.Dtos;

public class UpdatePasswordDto
{
    public Guid UserId { get; set; }
    public string OldPassword { get; set; }
    public string NewPassword { get; set; }
}