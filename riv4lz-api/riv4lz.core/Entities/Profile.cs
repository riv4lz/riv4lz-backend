using System.ComponentModel.DataAnnotations;
using riv4lz.core.Enums;

namespace riv4lz.core.Entities;

public class Profile
{
    [Key]
    public Guid Id { get; set; }

    public UserType UserType { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string FacebookUrl { get; set; }
    public string TwitterUrl { get; set; }
    public string DiscordUrl { get; set; }
    public string TwitchUrl { get; set; }
    public string WebsiteUrl { get; set; }

    public ICollection<Offer> Offers { get; set; }
    public ICollection<Image> Images { get; set; }
    public ICollection<Event> Events { get; set; }
}