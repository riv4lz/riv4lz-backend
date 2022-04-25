using System.ComponentModel.DataAnnotations;

namespace riv4lz.dataAccess.Entities;

public class EventEntity
{
    public Guid Id { get; set; }
    public Guid OrganisationId { get; set; }
}