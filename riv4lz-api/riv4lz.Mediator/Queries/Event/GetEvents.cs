using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using riv4lz.dataAccess;
using riv4lz.Mediator.Dtos.Events;

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

        public Handler(IMapper mapper, DataContext ctx)
        {
            _mapper = mapper;
            _ctx = ctx;
        }
        public async Task<List<EventDto>> Handle(Query request, CancellationToken cancellationToken)
        {
            var events = await _ctx.Events
                .Include(e => e.Teams)
                .Include(e => e.OrganisationProfile)
                .Select(e => _mapper.Map<EventDto>(e))
                .ToListAsync(cancellationToken);

            if (events.IsNullOrEmpty())
                return null;

            return events;
        }
    }
}