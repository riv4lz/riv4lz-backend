using System.ComponentModel.DataAnnotations;
using riv4lz.core.Enums;

namespace riv4lz.Mediator.Dtos.Events;

public class UpdateOfferDto
{
    [Required]
    public Guid Id { get; set; }
    [Required]
    public OfferStatus OfferStatus { get; set; }
}