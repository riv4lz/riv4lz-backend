using riv4lz.core.Entities;
using riv4lz.core.Enums;

namespace riv4lz.Mediator.Dtos.Profile;

public class ProfileDto
{
    public Guid Id { get; set; }
    public UserType UserType { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string ProfileImageUrl { get; set; }
    public string BannerImageUrl { get; set; }
    public string FacebookUrl { get; set; }
    public string TwitterUrl { get; set; }
    public string DiscordUrl { get; set; }
    public string TwitchUrl { get; set; }
}