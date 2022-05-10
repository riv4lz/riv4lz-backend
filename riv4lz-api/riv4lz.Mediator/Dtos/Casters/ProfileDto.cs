using riv4lz.core.Entities;

namespace riv4lz.Mediator.Dtos.Casters;

public class ProfileDto
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public Image? ProfileImage { get; set; }
    public Image? BannerImage { get; set; }
    public string? FacebookURL { get; set; }
    public string? TwitterURL { get; set; }
    public string? DiscordURL { get; set; }
    public string? TwitchURL { get; set; }
}