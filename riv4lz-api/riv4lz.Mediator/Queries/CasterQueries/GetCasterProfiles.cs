using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using riv4lz.dataAccess;
using riv4lz.dataAccess.Entities;
using riv4lz.Mediator.Dtos.Casters;

namespace riv4lz.Mediator.Queries.CasterQueries;

public class GetCasterProfiles
{
    public class Query : IRequest<List<CasterProfileDto>>
    {
    }
    
    public class Handler : IRequestHandler<Query, List<CasterProfileDto>>
    {
        private readonly IMapper _mapper;
        private readonly DataContext _ctx;

        public Handler(IMapper mapper, DataContext ctx)
        {
            _mapper = mapper;
            _ctx = ctx;
        }
        public async Task<List<CasterProfileDto>> Handle(Query request, CancellationToken cancellationToken)
        {
           var profileDtos = await _ctx.CasterProfiles.Select(
                u => _mapper.Map<CasterProfile, CasterProfileDto>(u)).ToListAsync(cancellationToken);

           return profileDtos != null ? profileDtos : null;
        }
    }
    
}
