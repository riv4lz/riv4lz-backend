using MediatR;
using riv4lz.dataAccess;
using riv4lz.domain;
using riv4lz.Mediator.Dtos;

namespace riv4lz.Mediator.Commands.OrgCommands;

public class CreateOrganisationProfile
{
    public class Command : IRequest<bool>
    {
        public RegisterOrganisationProfileDto RegisterOrganisationProfileDto { get; set; }
    }

    public class Handler : IRequestHandler<Command, bool>
    {
        
        public Handler()
        {
            
        }

        public async Task<bool> Handle(Command request, CancellationToken cancellationToken)
        {
            return true;
        }
    }
}