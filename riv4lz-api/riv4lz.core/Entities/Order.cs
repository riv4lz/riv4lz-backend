using System.ComponentModel.DataAnnotations.Schema;

namespace riv4lz.core.Entities;

public class Order
{
    public Guid Id { get; set; }

    [ForeignKey("Event")]
    public Guid EventId { get; set; }
    public Event Event { get; set; }


    public Guid CasterId { get; set; }
    public Profile Profile { get; set; }

    public Guid OrganisationId { get; set; }
    public OrganisationProfile OrganisationProfile { get; set; }
    
    
}