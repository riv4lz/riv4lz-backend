using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using riv4lz.Mediator.Commands;
using riv4lz.Mediator.Dtos;
using riv4lz.Mediator.Queries;
using riv4lz.Mediator.Queries.OrganisationQueries;

namespace riv4lz.casterApi.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class OffersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OffersController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpGet(nameof(GetOffer))]
        public async Task<ActionResult<OfferDto>> GetOffer(Guid offerId)
        {
            var offer = await _mediator.Send(new GetEventOffer.Query {OfferId = offerId});
            return Ok(offer);
        }
        
        [HttpGet(nameof(GetOffers))]
        public async Task<ActionResult<List<OfferDto>>> GetOffers(Guid eventId)
        {
            var offers = await _mediator.Send(new GetEventOffers.Query {EventId = eventId});
            return Ok(offers);
        }
        
        [HttpPost(nameof(CreateOffer))]
        public async Task<ActionResult<OfferDto>> CreateOffer(CreateOfferDto createOfferDto)
        {
            var result = await _mediator.Send(new CreateEventOffer.Command {CreateOfferDto = createOfferDto});
            if (result)
            {
                var offer = await _mediator.Send(new GetEventOffer.Query {OfferId = createOfferDto.Id});
                return Ok(offer);
            }
            return BadRequest("Error creating offer");
        }
        
        [HttpPut(nameof(UpdateOffer))]
        public async Task<ActionResult<bool>> UpdateOffer(UpdateOfferDto updateOfferDto)
        {
            return await _mediator.Send(new UpdateOfferStatus.Command {UpdateOfferDto = updateOfferDto});
        }
        
        [HttpDelete(nameof(DeleteOffer))]
        public async Task<ActionResult<bool>> DeleteOffer(Guid offerId)
        {
            return await _mediator.Send(new DeleteEventOffer.Command {OfferId = offerId});
        }
        
        
    }
}