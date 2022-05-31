using System.ComponentModel.DataAnnotations;
using riv4lz.core.Enums;

namespace riv4lz.Mediator.Dtos.Profile;

public class RegisterProfileDto
{
    [Required]
    public Guid Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public UserType UserType { get; set; }
    public string Description { get; set; }
    public string ProfileImageUrl { get; set; }
    public string BannerImageUrl { get; set; }
    public string FacebookUrl { get; set; }
    public string TwitterUrl { get; set; }
    public string DiscordUrl { get; set; }
    public string TwitchUrl { get; set; }
    public string WebsiteUrl { get; set; }
}