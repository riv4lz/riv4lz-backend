using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using riv4lz.Mediator.Dtos;
using riv4lz.Mediator.Queries;

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
            var offer = await _mediator.Send(new GetEventOffer.Query(offerId));
            return Ok(offer);
        }
        
        [HttpGet(nameof(GetOffers))]
        public async Task<ActionResult<OfferDto>> GetOffers(Guid eventId)
        {
            var offer = await _mediator.Send(new GetEventOffers.Query(eventId));
            return Ok(offer);
        }
        
        [HttpPost(nameof(CreateOffer))]
        public async Task<ActionResult<OfferDto>> CreateOffer(CreateOfferDto createOfferDto)
        {
            return null;
        }
        
        [HttpPut(nameof(UpdateOffer))]
        public async Task<ActionResult<OfferDto>> UpdateOffer(UpdateOfferDto updateOfferDto)
        {
            return null;
        }
        
        [HttpDelete(nameof(DeleteOffer))]
        public async Task<ActionResult<OfferDto>> DeleteOffer(Guid offerId)
        {
            return null;
        }
        
        
    }
}