namespace riv4lz.dataAccess.Entities;

public class Order
{
    public Guid Id { get; set; }
    
    public Guid EventId { get; set; }
    public Event Event { get; set; }
    
    public Guid OrganisationId { get; set; }
    public OrganisationProfile OrganisationProfile { get; set; }
    
    public Guid CasterId { get; set; }
    public CasterProfile CasterProfile { get; set; }
}