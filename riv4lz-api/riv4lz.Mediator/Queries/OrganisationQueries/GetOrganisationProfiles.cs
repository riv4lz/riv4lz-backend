using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using riv4lz.dataAccess;
using riv4lz.dataAccess.Entities;
using riv4lz.Mediator.Dtos.Organisations;

namespace riv4lz.Mediator.Queries.OrganisationQueries;

public class GetOrganisationProfiles
{
    public class Query : IRequest<List<OrganisationProfileDto>>
    {
    }
    
    public class Handler : BaseHandler, IRequestHandler<Query, List<OrganisationProfileDto>>
    {
        public async Task<List<OrganisationProfileDto>> Handle(Query request, CancellationToken cancellationToken)
        {
           var profileDtos = await _ctx.OrganisationProfiles.Select(
                u => _mapper.Map<OrganisationProfile, OrganisationProfileDto>(u))
               .ToListAsync(cancellationToken);

           return profileDtos != null ? profileDtos : null;
        }
    }
    
}
