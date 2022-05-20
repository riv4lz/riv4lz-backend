using AutoMapper;
using MediatR;
using riv4lz.core.Entities;
using riv4lz.dataAccess;
using riv4lz.Mediator.Dtos.Events;

namespace riv4lz.Mediator.Commands.Event;

public class CreateEvent
{
    public class Command : IRequest<bool>
    {
        public CreateEventDto CreateEventDto { get; set; }
    }

    public class Handler : IRequestHandler<Command, bool>
    {
        private readonly IMapper _mapper;
        private readonly DataContext _ctx;

        public Handler(IMapper mapper, DataContext ctx)
        {
            _mapper = mapper;
            _ctx = ctx;
        }
        public async Task<bool> Handle(Command request, CancellationToken cancellationToken)
        {
            var entity = await _ctx.Events
                .AddAsync(_mapper.Map<core.Entities.Event>(request.CreateEventDto), cancellationToken);
            
            entity.Entity.Teams = new List<Team>()
            {
                _mapper.Map<Team>(request.CreateEventDto.TeamOne),
                _mapper.Map<Team>(request.CreateEventDto.TeamTwo)
            };
            

            var result = await _ctx.SaveChangesAsync(cancellationToken);
            
            return result > 0;
        }
    }
}