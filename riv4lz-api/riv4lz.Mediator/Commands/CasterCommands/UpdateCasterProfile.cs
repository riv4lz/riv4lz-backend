using MediatR;
using riv4lz.Mediator.Dtos;

namespace riv4lz.Mediator.Commands.CasterCommands;

public class UpdateCasterProfile
{
    public class Command : IRequest
    {
        public UpdateCasterProfileDto UpdateCasterProfileDto { get; set; }
    }
    
    public class Handler : IRequestHandler<Command>
    {
        public Task<Unit> Handle(Command request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}