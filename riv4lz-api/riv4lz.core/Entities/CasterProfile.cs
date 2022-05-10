using System.ComponentModel.DataAnnotations;
using riv4lz.core.Models;

namespace riv4lz.core.Entities;

public class CasterProfile
{
    [Key]
    public Guid CasterId { get; set; }
    public string? GamerTag { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Description { get; set; }
    public string? ProfileImage { get; set; }
    public string? BannerImage { get; set; }
    public string? FacebookURL { get; set; }
    public string? TwitterURL { get; set; }
    public string? DiscordURL { get; set; }
    public string? TwitchURL { get; set; }

    public ICollection<Offer>? Offers { get; set; }
    public ICollection<Order>? Orders { get; set; }
    public ICollection<Image> Images { get; set; }
}