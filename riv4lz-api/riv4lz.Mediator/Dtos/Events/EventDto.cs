using riv4lz.core.Models;
using riv4lz.dataAccess.Entities;

namespace riv4lz.Mediator.Dtos.Events;

public class EventDto
{
    public Guid Id { get; set; }
    public string Organiser { get; set; }
    public DateTime Time { get; set; }
    public string Description { get; set; }
    public string TeamOne { get; set; }
    public string TeamTwo { get; set; }
    public double Price { get; set; }
    public EventStatus EventStatus { get; set; } = EventStatus.PENDING;
    
    public Guid OrganisationId { get; set; }
    public OrganisationProfile OrganisationProfile { get; set; }

    public ICollection<Offer>? Offers { get; set; }
}