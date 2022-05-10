using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using riv4lz.Mediator.Commands.EventCommands;
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
            return await _mediator.Send(new GetEvent.Query {EventId = eventId});
        }
        
        [HttpPost(nameof(CreateEvent))]
        public async Task<ActionResult<bool>> CreateEvent(CreateEventDto createEventDto)
        {
            return await _mediator.Send(new CreateEvent.Command {CreateEventDto = createEventDto});
        }
        
        [HttpPut(nameof(UpdateEvent))]
        public async Task<ActionResult<EventDto>> UpdateEvent(Guid eventId, UpdateEventDto updateEventDto)
        {
            return null;
        }
        
        [HttpGet(nameof(GetTeams))]
        public async Task<ActionResult<List<TeamDto>>> GetTeams()
        {
            return await _mediator.Send(new GetTeams.Query());
        }
        
        
    }
}