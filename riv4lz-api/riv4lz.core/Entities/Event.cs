using System.ComponentModel.DataAnnotations;

namespace riv4lz.core.Entities;

public class Event
{
    [Key]
    public Guid Id { get; set; }
    public string Organiser { get; set; }
    public DateTime Time { get; set; }
    public string Description { get; set; }
    public string TeamOne { get; set; }
    public string TeamTwo { get; set; }
    public double Price { get; set; }

    public Guid OrganisationId { get; set; }
    [Required]
    public OrganisationProfile OrganisationProfile { get; set; }
    
    public Order Order { get; set; }

    public ICollection<Offer>? Offers { get; set; }
}
