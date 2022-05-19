using System.ComponentModel.DataAnnotations;
using riv4lz.core.Enums;

namespace riv4lz.Mediator.Dtos.Events;

public class CreateOfferDto
{
    [Required]
    public Guid Id { get; set; }
    [Required]
    public OfferStatus OfferStatus { get; set; } = OfferStatus.Pending;
    [Required]
    public Guid CasterId { get; set; }
    [Required]
    public Guid EventId { get; set; }
}