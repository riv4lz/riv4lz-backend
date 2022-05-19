using riv4lz.core.Enums;

using riv4lz.Mediator.Dtos.Casters;

namespace riv4lz.Mediator.Dtos.Events;

public class EventDto
{
    public Guid Id { get; set; }
    public EventStatus EventStatus { get; set; }
    public DateTime Time { get; set; }
    public List<TeamDto> Teams { get; set; }
    public double Price { get; set; }
    
    public ProfileDto OrganisationProfile { get; set; }
}