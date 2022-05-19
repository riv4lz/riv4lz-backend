using Microsoft.AspNetCore.Mvc;
using riv4lz.Mediator.Dtos;
using riv4lz.Mediator.Dtos.Events;

namespace riv4lz.casterApi.Interfaces;

public interface IEventController
{
    Task<ActionResult<List<EventDto>>> GetEvents();
    Task<ActionResult<EventDto>> GetEvent(Guid eventId);
    Task<ActionResult<bool>> CreateEvent(CreateEventDto createEventDto);
    Task<ActionResult<EventDto>> UpdateEvent(Guid eventId, UpdateEventDto updateEventDto);
    Task<ActionResult<bool>> DeleteEvent(Guid eventId);
    Task<ActionResult<List<TeamDto>>> GetTeams();
}