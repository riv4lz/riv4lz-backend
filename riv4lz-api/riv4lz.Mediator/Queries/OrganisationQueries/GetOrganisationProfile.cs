using AutoMapper;
using MediatR;
using riv4lz.dataAccess;
using riv4lz.dataAccess.Entities;
using riv4lz.Mediator.Dtos.Organisations;

namespace riv4lz.Mediator.Queries.OrganisationQueries;

public class GetOrganisationProfile
{
    public class Query : IRequest<OrganisationProfileDto>
    {
        public Guid OrganisationId { get; set; }
    }
    
    public class Handler : IRequestHandler<Query, OrganisationProfileDto>
    {
        private readonly IMapper _mapper;
        private readonly DataContext _ctx;

        public Handler(IMapper mapper, DataContext ctx)
        {
            _mapper = mapper;
            _ctx = ctx;
        }
        public async Task<OrganisationProfileDto> Handle(Query request, CancellationToken cancellationToken)
        {
           var entity = _ctx.OrganisationProfiles.FirstOrDefault(
                u => u.OrganisationId == request.OrganisationId);
           
           return entity != null ? _mapper.Map<OrganisationProfile, OrganisationProfileDto>(entity) : null;
           
        }
    }
}