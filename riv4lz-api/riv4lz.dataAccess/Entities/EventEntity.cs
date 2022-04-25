namespace riv4lz.dataAccess.Entities;

public class EventEntity
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