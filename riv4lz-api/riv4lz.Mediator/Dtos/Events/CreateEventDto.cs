using riv4lz.core.Entities;
using riv4lz.core.Enums;

namespace riv4lz.Mediator.Dtos.Events;

public class CreateEventDto
{
    public Guid Id { get; set; }
    public Guid OrganisationId { get; set; }
    public DateTime Time { get; set; }
    public string Description { get; set; }
    public string Game { get; set; }
    public TeamDto TeamOne { get; set; }
    public TeamDto TeamTwo { get; set; }
    public double Price { get; set; }
    public EventStatus EventStatus { get; set; }
}