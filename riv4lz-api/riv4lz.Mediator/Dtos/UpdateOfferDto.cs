using riv4lz.core.Models;

namespace riv4lz.Mediator.Dtos;

public class UpdateOfferDto
{
    public Guid Id { get; set; }
    public OfferStatus OfferStatus { get; set; }
}