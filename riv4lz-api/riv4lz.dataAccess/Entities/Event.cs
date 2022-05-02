using Microsoft.EntityFrameworkCore.Metadata.Internal;
using riv4lz.core.Models;

namespace riv4lz.dataAccess.Entities;

public class Event
{
    public Guid Id { get; set; }
    public string Organiser { get; set; }
    public DateTime Time { get; set; }
    public string Description { get; set; }
    public string TeamOne { get; set; }
    public string TeamTwo { get; set; }
    public double Price { get; set; }

    public Guid OrganisationId { get; set; }
    public OrganisationProfile OrganisationProfile { get; set; }

    public ICollection<Offer>? Offers { get; set; }
}
