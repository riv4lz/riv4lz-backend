using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using riv4lz.Mediator.Dtos;
using riv4lz.Mediator.Dtos.Events;
using riv4lz.Mediator.Queries.EventQueries;

namespace riv4lz.casterApi.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EventController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(nameof(GetEvents))]
        public async Task<ActionResult<List<EventDto>>> GetEvents()
        {
            return await _mediator.Send(new GetEvents.Query());
        }
        
        [HttpGet(nameof(GetEvent))]
        public async Task<ActionResult<EventDto>> GetEvent(Guid eventId)
        {
            return null;
        }
        
        [HttpPost(nameof(CreateEvent))]
        public async Task<ActionResult<EventDto>> CreateEvent(CreateEventDto createEventDto)
        {
            return null;
        }
        
        [HttpPut(nameof(UpdateEvent))]
        public async Task<ActionResult<EventDto>> UpdateEvent(Guid eventId, UpdateEventDto updateEventDto)
        {
            return null;
        }
        
    }
}