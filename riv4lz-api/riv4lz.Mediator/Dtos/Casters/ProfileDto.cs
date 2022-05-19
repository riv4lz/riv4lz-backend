using riv4lz.core.Entities;
using riv4lz.core.Models;

namespace riv4lz.Mediator.Dtos.Casters;

public class ProfileDto
{
    public Guid Id { get; set; }
    public UserType UserType { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public Image? ProfileImage { get; set; }
    public Image? BannerImage { get; set; }
    public string? FacebookURL { get; set; }
    public string? TwitterURL { get; set; }
    public string? DiscordURL { get; set; }
    public string? TwitchURL { get; set; }
}