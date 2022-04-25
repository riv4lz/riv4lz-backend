using AutoMapper;
using MediatR;
using riv4lz.dataAccess;
using riv4lz.dataAccess.Entities;
using riv4lz.Mediator.Dtos;

namespace riv4lz.Mediator.Commands.EventCommands;

public class CreateEvent
{
    public class Command : IRequest<bool>
    {
        public CreateEventDto CreateEventDto { get; set; }
    }

    public class Handler : IRequestHandler<Command, bool>
    {
        private readonly CasterDbContext _ctx;
        private readonly IMapper _mapper;

        public Handler(CasterDbContext ctx, IMapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }

        public async Task<bool> Handle(Command request, CancellationToken cancellationToken)
        {
            await _ctx.Events.AddAsync(
                _mapper.Map<CreateEventDto, EventEntity>(
                    request.CreateEventDto), cancellationToken);

            var result = await _ctx.SaveChangesAsync(cancellationToken);
            
            return result > 0;
        }
    }
}