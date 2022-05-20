using riv4lz.core.Enums;
using riv4lz.Mediator.Dtos.Profile;

namespace riv4lz.Mediator.Dtos.Events;

public class OfferDto
{
    public Guid Id { get; set; }
    public OfferStatus OfferStatus { get; set; }
    public ProfileDto Caster { get; set; }
}