using riv4lz.core.Models;
using riv4lz.Mediator.Dtos.Casters;

namespace riv4lz.Mediator.Dtos;

public class OfferDto
{
    public Guid Id { get; set; }
    public OfferStatus OfferStatus { get; set; }
    public ProfileDto Caster { get; set; }
}