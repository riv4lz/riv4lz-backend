using riv4lz.core.Models;

namespace riv4lz.Mediator.Dtos;

public class CreateOfferDto
{
    public Guid Id { get; set; }
    public OfferStatus OfferStatus { get; set; } = OfferStatus.PENDING;
    public Guid CasterId { get; set; }
    public Guid EventId { get; set; }
}