using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using riv4lz.dataAccess;
using riv4lz.Mediator.Dtos.Organisations;

namespace riv4lz.Mediator.Commands.OrgCommands;

public class UpdateOrganisationProfile
{
    public class Command : IRequest<bool>
    {
        public UpdateOrganisationProfileDto UpdateOrganisationProfileDto { get; set; }
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