using AutoMapper;
using MediatR;
using riv4lz.dataAccess;
using riv4lz.dataAccess.Entities;
using riv4lz.Mediator.Dtos;

namespace riv4lz.Mediator.Queries.OrganisationQueries;

public class GetOrganisationProfile
{
    public class Query : IRequest<OrganisationProfileDto>
    {
        public Guid OrganisationId { get; set; }
    }
    
    public class Handler : IRequestHandler<Query, OrganisationProfileDto>
    {
        private readonly DataContext _ctx;
        private readonly IMapper _mapper;


        public Handler(DataContext ctx, IMapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }

        public async Task<OrganisationProfileDto> Handle(Query request, CancellationToken cancellationToken)
        {
           var entity = _ctx.OrganisationProfiles.FirstOrDefault(
                u => u.OrganisationId == request.OrganisationId);
           
           return entity != null ? _mapper.Map<OrganisationProfile, OrganisationProfileDto>(entity) : null;
           
        }
    }
}