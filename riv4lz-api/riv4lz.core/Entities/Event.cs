using System.ComponentModel.DataAnnotations;

namespace riv4lz.core.Entities;

public class Event
{
    [Key]
    public Guid Id { get; set; }
    public DateTime Time { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public string Game { get; set; }
    
    public Guid OrganisationId { get; set; }
    [Required]
    public Profile OrganisationProfile { get; set; }
    public ICollection<Offer>? Offers { get; set; }
    public ICollection<Team> Teams { get; set; }
}
