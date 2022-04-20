using MediatR;
using riv4lz.Mediator.Dtos;

namespace riv4lz.Mediator;

public class EditCasterProfile
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