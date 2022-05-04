using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using riv4lz.core.Entities;
using riv4lz.dataAccess;
using riv4lz.Mediator.Dtos.Organisations;

namespace riv4lz.Mediator.Queries.OrganisationQueries;

public class GetOrganisationProfiles
{
    public class Query : IRequest<List<OrganisationProfileDto>>
    {
    }
    
    public class Handler : IRequestHandler<Query, List<OrganisationProfileDto>>
    {
        private readonly IMapper _mapper;
        private readonly DataContext _ctx;

        public Handler(IMapper mapper, DataContext ctx)
        {
            _mapper = mapper;
            _ctx = ctx;
        }
        public async Task<List<OrganisationProfileDto>> Handle(Query request, CancellationToken cancellationToken)
        {
           var profileDtos = await _ctx.OrganisationProfiles.Select(
                u => _mapper.Map<OrganisationProfile, OrganisationProfileDto>(u))
               .ToListAsync(cancellationToken);

           return profileDtos != null ? profileDtos : null;
        }
    }
    
}
