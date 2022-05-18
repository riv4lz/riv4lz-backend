using Microsoft.AspNetCore.Mvc;
using riv4lz.casterApi.Interfaces;
using riv4lz.Mediator.Commands.EventCommands;
using riv4lz.Mediator.Dtos;
using riv4lz.Mediator.Dtos.Events;
using riv4lz.Mediator.Queries.EventQueries;

namespace riv4lz.casterApi.Controllers
{
    public class EventController : BaseController, IEventController
    {

        [HttpGet(nameof(GetEvents))]
        public async Task<ActionResult<List<EventDto>>> GetEvents()
        {
            return await Mediator.Send(new GetEvents.Query());
        }
        
        [HttpGet(nameof(GetEvent))]
        public async Task<ActionResult<EventDto>> GetEvent(Guid eventId)
        {
            return await Mediator.Send(new GetEvent.Query {EventId = eventId});
        }
        
        [HttpPost(nameof(CreateEvent))]
        public async Task<ActionResult<bool>> CreateEvent(CreateEventDto createEventDto)
        {
            return await Mediator.Send(new CreateEvent.Command {CreateEventDto = createEventDto});
        }
        
        [HttpPut(nameof(UpdateEvent))]
        public async Task<ActionResult<EventDto>> UpdateEvent(Guid eventId, UpdateEventDto updateEventDto)
        {
            return null;
        }

        public Task<ActionResult<bool>> DeleteEvent(Guid eventId)
        {
            throw new NotImplementedException();
        }

        [HttpGet(nameof(GetTeams))]
        public async Task<ActionResult<List<TeamDto>>> GetTeams()
        {
            return await Mediator.Send(new GetTeams.Query());
        }
        
        
    }
}