using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using riv4lz.Mediator.Dtos;

namespace riv4lz.casterApi.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public EventController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet(nameof(GetEvents))]
        public async Task<ActionResult<List<EventDto>>> GetEvents()
        {
            return null;
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