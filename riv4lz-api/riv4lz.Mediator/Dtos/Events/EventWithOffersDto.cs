using riv4lz.core.Entities;
using riv4lz.core.Enums;
using riv4lz.Mediator.Dtos.Profile;

namespace riv4lz.Mediator.Dtos.Events;

public class EventWithOffersDto
{
    public Guid Id { get; set; }
    public DateTime Time { get; set; }
    public string Description { get; set; }
    public List<TeamDto> Teams { get; set; }
    public double Price { get; set; }
    public EventStatus EventStatus { get; set; }
    
    public Guid OrganisationId { get; set; }
    public ProfileDto OrganisationProfile { get; set; }

    public ICollection<Offer> Offers { get; set; }
}