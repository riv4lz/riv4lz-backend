namespace riv4lz.Mediator.Dtos;

public class CreateEventDto
{
    public Guid Id { get; set; }
    public Guid OrganisationId { get; set; }
    public string Organiser { get; set; }
    public DateTime Time { get; set; }
    public string Description { get; set; }
    public string TeamOne { get; set; }
    public string TeamTwo { get; set; }
    public double Price { get; set; }
}