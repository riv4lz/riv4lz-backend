using Microsoft.AspNetCore.Mvc;
using riv4lz.casterApi.Interfaces;
using riv4lz.Mediator.Commands;
using riv4lz.Mediator.Dtos.Events;
using riv4lz.Mediator.Queries.EventQueries;

namespace riv4lz.casterApi.Controllers
{
    public class OffersController : BaseController, IOffersController
    {
        [HttpGet(nameof(GetOffer))]
        public async Task<ActionResult<OfferDto>> GetOffer(Guid offerId)
        {
            var offer = await Mediator.Send(new GetEventOffer.Query {OfferId = offerId});
            return Ok(offer);
        }
        
        [HttpGet(nameof(GetOffers))]
        public async Task<ActionResult<List<OfferDto>>> GetOffers(Guid eventId)
        {
            var offers = await Mediator.Send(new GetEventOffers.Query {EventId = eventId});
            return Ok(offers);
        }
        
        [HttpPost(nameof(CreateOffer))]
        public async Task<ActionResult<OfferDto>> CreateOffer(CreateOfferDto createOfferDto)
        {
            var result = await Mediator.Send(new CreateEventOffer.Command {CreateOfferDto = createOfferDto});
            if (result)
            {
                var offer = await Mediator.Send(new GetEventOffer.Query {OfferId = createOfferDto.Id});
                return Ok(offer);
            }
            return BadRequest("Error creating offer");
        }
        
        [HttpPut(nameof(UpdateOffer))]
        public async Task<ActionResult<bool>> UpdateOffer(UpdateOfferDto updateOfferDto)
        {
            return await Mediator.Send(new UpdateOfferStatus.Command {UpdateOfferDto = updateOfferDto});
        }
        
        [HttpPut(nameof(AcceptOffer))]
        public async Task<ActionResult<bool>> AcceptOffer(UpdateOfferDto updateOfferDto)
        {
            var result = await Mediator.Send(new AcceptOffer.Command {UpdateOfferDto = updateOfferDto});

            if (result)
            {
                
            }

            return false;
        }
        
        [HttpPut(nameof(RejectOffer))]
        public async Task<ActionResult<bool>> RejectOffer(UpdateOfferDto updateOfferDto)
        {
            return await Mediator.Send(new RejectOffer.Command {UpdateOfferDto = updateOfferDto});
        }
        
        [HttpDelete(nameof(DeleteOffer))]
        public async Task<ActionResult<bool>> DeleteOffer(Guid offerId)
        {
            return await Mediator.Send(new DeleteEventOffer.Command {OfferId = offerId});
        }
    }
}