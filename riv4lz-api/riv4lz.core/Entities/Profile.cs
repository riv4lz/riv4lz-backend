using System.ComponentModel.DataAnnotations;
using riv4lz.core.Models;

namespace riv4lz.core.Entities;

public class Profile
{
    [Key]
    public Guid Id { get; set; }

    public UserType UserType { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? FacebookURL { get; set; }
    public string? TwitterURL { get; set; }
    public string? DiscordURL { get; set; }
    public string? TwitchURL { get; set; }
    public string? WebsiteURL { get; set; }

    public ICollection<Offer>? Offers { get; set; }
    public ICollection<Order>? Orders { get; set; }
    public ICollection<Image>? Images { get; set; }
    public ICollection<Event>? Events { get; set; }
}