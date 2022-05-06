using riv4lz.core.Entities;
using riv4lz.core.Models;
using riv4lz.Mediator.Dtos.Organisations;

namespace riv4lz.Mediator.Dtos.Events;

public class EventDto
{
    public Guid Id { get; set; }
    
    public DateTime Time { get; set; }
    public List<TeamDto> Teams { get; set; }
    public double Price { get; set; }
    
    public OrganisationProfileDto OrganisationProfile { get; set; }
}