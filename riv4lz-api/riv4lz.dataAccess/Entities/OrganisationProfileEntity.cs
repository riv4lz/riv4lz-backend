using System.ComponentModel.DataAnnotations;

namespace riv4lz.dataAccess.Entities;

public class OrganisationProfileEntity
{
    [Key]
    public Guid OrganisationId { get; set; }
}