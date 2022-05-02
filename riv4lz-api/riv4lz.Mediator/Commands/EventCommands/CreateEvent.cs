using AutoMapper;
using MediatR;
using riv4lz.dataAccess;
using riv4lz.dataAccess.Entities;
using riv4lz.Mediator.Dtos.Events;

namespace riv4lz.Mediator.Commands.EventCommands;

public class CreateEvent
{
    public class Command : IRequest<bool>
    {
        public CreateEventDto CreateEventDto { get; set; }
    }

    public class Handler : BaseHandler, IRequestHandler<Command, bool>
    {
        public async Task<bool> Handle(Command request, CancellationToken cancellationToken)
        {
            await _ctx.Events.AddAsync(
                _mapper.Map<CreateEventDto, Event>(
                    request.CreateEventDto), cancellationToken);

            var result = await _ctx.SaveChangesAsync(cancellationToken);
            
            return result > 0;
        }
    }
}