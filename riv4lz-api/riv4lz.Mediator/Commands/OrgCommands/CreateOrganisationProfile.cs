using AutoMapper;
using MediatR;
using riv4lz.core.Entities;
using riv4lz.dataAccess;
using riv4lz.Mediator.Dtos.Organisations;

namespace riv4lz.Mediator.Commands.OrgCommands;

public class CreateOrganisationProfile
{
    public class Command : IRequest<bool>
    {
        public RegisterOrganisationProfileDto RegisterOrganisationProfileDto { get; set; }
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
            /*
            await _ctx.Profiles.AddAsync(
                _mapper.Map<RegisterOrganisationProfileDto, OrganisationProfile>(
                    request.RegisterOrganisationProfileDto), cancellationToken);

            var result = await _ctx.SaveChangesAsync(cancellationToken);
            
            return result > 0;
            */
            return false;
        }
    }
}