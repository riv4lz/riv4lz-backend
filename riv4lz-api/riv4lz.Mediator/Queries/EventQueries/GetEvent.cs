using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using riv4lz.core.Entities;
using riv4lz.dataAccess;
using riv4lz.Mediator.Dtos.Events;

namespace riv4lz.Mediator.Queries.EventQueries;

public class GetEvent
{
    public class Query : IRequest<EventDto?>
    {
        public Guid EventId { get; set; }
    }
    
    public class Handler : IRequestHandler<Query, EventDto?>
    {
        private readonly IMapper _mapper;
        private readonly DataContext _ctx;

        public Handler(IMapper mapper, DataContext ctx)
        {
            _mapper = mapper;
            _ctx = ctx;
        }
        public async Task<EventDto?> Handle(Query request, CancellationToken cancellationToken)
        {
            var entity = await _ctx.Events
                .Include(t => t.Teams)
                .Include(o => o.OrganisationProfile)
                .FirstAsync(e => e.Id == request.EventId, cancellationToken);
           
            return entity != null ? _mapper.Map<EventDto>(entity) : null;
           
        }
    }
}