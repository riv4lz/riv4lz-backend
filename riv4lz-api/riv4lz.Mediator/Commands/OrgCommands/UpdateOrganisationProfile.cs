using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using riv4lz.dataAccess;
using riv4lz.Mediator.Dtos;

namespace riv4lz.Mediator.Commands.OrgCommands;

public class UpdateOrganisationProfile
{
    public class Command : IRequest<bool>
    {
        public UpdateOrganisationProfileDto UpdateOrganisationProfileDto { get; set; }
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
            var organisation = await _ctx.OrganisationProfiles.FirstOrDefaultAsync(
                x => x.OrganisationId == request.UpdateOrganisationProfileDto.OrganisationId, cancellationToken);
            
            if (organisation == null)
            {
                return false;
            }
            
            _mapper.Map(request.UpdateOrganisationProfileDto, organisation);
            
            var result = await _ctx.SaveChangesAsync(cancellationToken);
            
            return result > 0;
        }
    }
}