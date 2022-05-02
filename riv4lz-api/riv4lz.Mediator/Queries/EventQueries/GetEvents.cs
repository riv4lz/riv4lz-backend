using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using riv4lz.dataAccess;
using riv4lz.dataAccess.Entities;
using riv4lz.Mediator.Dtos.Events;

namespace riv4lz.Mediator.Queries.EventQueries;

public class GetEvents
{
    public class Query : IRequest<List<EventDto>>
    {
        
    }
    
    public class Handler : BaseHandler, IRequestHandler<Query, List<EventDto>>
    {
        public async Task<List<EventDto>> Handle(Query request, CancellationToken cancellationToken)
        {
            var events = await _ctx.Events
                .Select(e => _mapper.Map<Event, EventDto>(e)).ToListAsync(cancellationToken);

            return events;

        }
    }
}