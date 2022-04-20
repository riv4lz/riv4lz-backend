using MediatR;
using riv4lz.core.IServices;
using riv4lz.core.Models;
using riv4lz.domain.IRepositories;

namespace riv4lz.Mediator;

public class CreateCasterProfile
{
    public class Command : IRequest
    {
        public CasterProfile CasterProfile { get; set; }
    }
    
    public class Handler: IRequestHandler<Command>
    {
        private readonly ICasterService _casterService;

        public Handler(ICasterService casterService)
        {
            _casterService = casterService;
        }

        public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
        {
            var result = _casterService.Create(request.CasterProfile);

            return Unit.Value;
        }
    }
    

}