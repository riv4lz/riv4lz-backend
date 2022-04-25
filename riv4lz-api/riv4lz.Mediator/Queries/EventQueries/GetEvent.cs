using AutoMapper;
using MediatR;
using riv4lz.dataAccess;
using riv4lz.dataAccess.Entities;
using riv4lz.Mediator.Dtos;

namespace riv4lz.Mediator.Queries.EventQueries;

public class GetEvent
{
    public class Query : IRequest<EventDto>
    {
        public Guid EventId { get; set; }
    }
    
    public class Handler : IRequestHandler<Query, EventDto>
    {
        private readonly DataContext _ctx;
        private readonly IMapper _mapper;


        public Handler(DataContext ctx, IMapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }

        public async Task<EventDto> Handle(Query request, CancellationToken cancellationToken)
        {
            var entity = _ctx.Events.FirstOrDefault(
                u => u.Id == request.EventId);
           
            return entity != null ? _mapper.Map<Event, EventDto>(entity) : null;
           
        }
    }
}