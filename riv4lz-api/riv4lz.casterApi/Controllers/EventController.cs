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
            var events = await Mediator.Send(new GetEvents.Query());
            
            if(events is null)
                return BadRequest("No events found");

            return Ok(events);
        }
        
        [HttpGet(nameof(GetEvent))]
        public async Task<ActionResult<EventDto>> GetEvent(Guid eventId)
        {
            var eventDto = await Mediator.Send(new GetEvent.Query {EventId = eventId});
            
            if(eventDto is null)
                return BadRequest("No event found");
            
            return Ok(eventDto);
        }
        
        [HttpPost(nameof(CreateEvent))]
        public async Task<ActionResult<bool>> CreateEvent(CreateEventDto createEventDto)
        {
            var result = await Mediator
                .Send(new CreateEvent.Command {CreateEventDto = createEventDto});
            
            if(!result)
                return BadRequest("Failed to create event");
            
            return Ok(result);
        }
        
        [HttpPut(nameof(UpdateEvent))]
        public async Task<ActionResult<bool>> UpdateEvent(Guid eventId, UpdateEventDto updateEventDto)
        {
            if(eventId != updateEventDto.Id)
                return BadRequest("Invalid event data");
            
            var result = await Mediator.Send(new UpdateEvent.Command {UpdateEventDto = updateEventDto});
            
            if(!result)
                return BadRequest("Failed to update event");
            
            return Ok(true);
        }

        [HttpDelete(nameof(DeleteEvent))]
        public async Task<ActionResult<bool>> DeleteEvent(EventDto eventDto)
        {
            var result = await Mediator
                .Send(new DeleteEvent.Command {EventDto = eventDto});
            
            if(!result)
                return BadRequest("Failed to delete event");
            
            return Ok(true);
        }

        [HttpGet(nameof(GetTeams))]
        public async Task<ActionResult<List<TeamDto>>> GetTeams()
        {
            var teams = await Mediator.Send(new GetTeams.Query());
            
            if(teams is null)
                return BadRequest("Failed to load teams from database");
            
            return Ok(teams);
        }
    }
}