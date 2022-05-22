using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using riv4lz.dataAccess;
using riv4lz.Mediator.Dtos.Events;
using riv4lz.Mediator.Helpers;

namespace riv4lz.Mediator.Queries.Event;

public class GetEvents
{
    public class Query : IRequest<List<EventDto>>
    {
        
    }
    
    public class Handler : IRequestHandler<Query, List<EventDto>>
    {
        private readonly IMapper _mapper;
        private readonly DataContext _ctx;
        private readonly RedisInstance _redis;

        public Handler(IMapper mapper, DataContext ctx, RedisInstance redis)
        {
            _mapper = mapper;
            _ctx = ctx;
            _redis = redis;
        }
        public async Task<List<EventDto>> Handle(Query request, CancellationToken cancellationToken)
        {
            var cachedEvents = await _redis.Get<List<EventDto>>("events");

            if (cachedEvents.IsNullOrEmpty())
            {
                var events = await _ctx.Events
                    .Include(e => e.Teams)
                    .Include(e => e.OrganisationProfile)
                    .Select(e => _mapper.Map<EventDto>(e))
                    .ToListAsync(cancellationToken);

                if (events.IsNullOrEmpty())
                    return null;
                
                _redis.Set("events", events);

                return events;
            }

            return cachedEvents;
        }
    }
}