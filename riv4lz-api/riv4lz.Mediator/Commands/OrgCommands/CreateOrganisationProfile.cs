using AutoMapper;
using MediatR;
using riv4lz.dataAccess;
using riv4lz.dataAccess.Entities;
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
        private readonly CasterDbContext _ctx;
        private readonly IMapper _mapper;

        public Handler(CasterDbContext ctx, IMapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }

        public async Task<bool> Handle(Command request, CancellationToken cancellationToken)
        {
            await _ctx.OrganisationProfiles.AddAsync(
                _mapper.Map<RegisterOrganisationProfileDto, OrganisationProfileEntity>(
                    request.RegisterOrganisationProfileDto), cancellationToken);

            var result = await _ctx.SaveChangesAsync(cancellationToken);
            
            return result > 0;
        }
    }
}