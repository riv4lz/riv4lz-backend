using AutoMapper;
using MediatR;
using riv4lz.dataAccess;
using riv4lz.dataAccess.Entities;
using riv4lz.Mediator.Dtos;

namespace riv4lz.Mediator.Queries.EventQueries;

public class GetEvents
{
    public class Query : IRequest<List<EventDto>>
    {
        
    }
    
    public class Handler : IRequestHandler<Query, List<EventDto>>
    {
        private readonly CasterDbContext _ctx;
        private readonly IMapper _mapper;


        public Handler(CasterDbContext ctx, IMapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }

        public async Task<List<EventDto>> Handle(Query request, CancellationToken cancellationToken)
        {
            var events = _ctx.Events
                .Select(e => _mapper.Map<EventEntity, EventDto>(e)).ToList();

            return events;

        }
    }
}