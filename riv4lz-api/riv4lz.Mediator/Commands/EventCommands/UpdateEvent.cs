using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using riv4lz.dataAccess;
using riv4lz.Mediator.Dtos.Events;

namespace riv4lz.Mediator.Commands.EventCommands;

public class UpdateEvent
{
    public class Command : IRequest<bool>
    {
        public UpdateEventDto UpdateEventDto { get; set; }
    }

    public class Handler : IRequestHandler<Command, bool>
    {
        private readonly DataContext _ctx;
        private readonly IMapper _mapper;

        public Handler(DataContext ctx, IMapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }

        public async Task<bool> Handle(Command request, CancellationToken cancellationToken)
        {
            var eventToUpdate = await _ctx.Events
                .FirstOrDefaultAsync(x => x.Id == request.UpdateEventDto.Id, cancellationToken);

            if (eventToUpdate is null)
                return false;
            
            _mapper.Map(request.UpdateEventDto, eventToUpdate);

            var result = await _ctx.SaveChangesAsync(cancellationToken) > 0;
            
            return result;
        }
    }
}