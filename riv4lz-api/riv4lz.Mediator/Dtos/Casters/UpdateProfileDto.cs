using System.ComponentModel.DataAnnotations;
using riv4lz.core.Enums;

namespace riv4lz.Mediator.Dtos.Casters;

public class UpdateProfileDto
{
    [Required]
    public Guid Id { get; set; }
    
    [Required]
    public UserType UserType { get; set; }
    [Required]
    public string Name { get; set; }
    public string Description { get; set; }
    public string ProfileImage { get; set; }
    public string BannerImage { get; set; }
    public string FacebookURL { get; set; }
    public string TwitterURL { get; set; }
    public string DiscordURL { get; set; }
    public string TwitchURL { get; set; }
    public string WebsiteURL { get; set; }
}