using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using riv4lz.dataAccess;
using riv4lz.dataAccess.Entities;
using riv4lz.Mediator.Dtos;
using riv4lz.Mediator.Dtos.Events;

namespace riv4lz.Mediator.Queries.EventQueries;

public class GetEventsWithOffers
{
    public class Query : IRequest<List<EventDto>>
    {
        
    }
    
    public class Handler : IRequestHandler<Query, List<EventDto>>
    {
        private readonly DataContext _ctx;
        private readonly IMapper _mapper;


        public Handler(DataContext ctx, IMapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }

        public async Task<List<EventDto>> Handle(Query request, CancellationToken cancellationToken)
        {
            var events = await _ctx.Events
                .Include(x => x.Offers)
                .ThenInclude(o => o.Caster)
                .Select(e => _mapper.Map<Event, EventDto>(e))
                .ToListAsync(cancellationToken);

            return events;
        }
    }
}