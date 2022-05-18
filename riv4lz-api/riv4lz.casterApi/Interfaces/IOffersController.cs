using Microsoft.AspNetCore.Mvc;
using riv4lz.Mediator.Dtos.Events;

namespace riv4lz.casterApi.Interfaces;

public interface IOffersController
{
    Task<ActionResult<OfferDto>> GetOffer(Guid offerId);
    Task<ActionResult<List<OfferDto>>> GetOffers(Guid eventId);
    Task<ActionResult<OfferDto>> CreateOffer(CreateOfferDto createOfferDto);
    Task<ActionResult<bool>> UpdateOffer(UpdateOfferDto updateOfferDto);
    Task<ActionResult<bool>> AcceptOffer(UpdateOfferDto updateOfferDto);
    Task<ActionResult<bool>> RejectOffer(UpdateOfferDto updateOfferDto);
    Task<ActionResult<bool>> DeleteOffer(Guid offerId);
}