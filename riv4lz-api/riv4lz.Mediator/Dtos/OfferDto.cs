using riv4lz.core.Models;
using riv4lz.dataAccess.Entities;
using riv4lz.Mediator.Dtos.Casters;
using riv4lz.Mediator.Dtos.Events;

namespace riv4lz.Mediator.Dtos;

public class OfferDto
{
    public Guid Id { get; set; }
    public OfferStatus OfferStatus { get; set; }
    public CasterProfileDto Caster { get; set; }
}