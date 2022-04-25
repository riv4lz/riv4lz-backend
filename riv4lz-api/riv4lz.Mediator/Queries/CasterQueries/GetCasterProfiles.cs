using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using riv4lz.dataAccess;
using riv4lz.dataAccess.Entities;
using riv4lz.Mediator.Dtos;

namespace riv4lz.Mediator.Queries.CasterQueries;

public class GetCasterProfiles
{
    public class Query : IRequest<List<CasterProfileDto>>
    {
    }
    
    public class Handler : IRequestHandler<Query, List<CasterProfileDto>>
    {
        private readonly DataContext _ctx;
        private readonly IMapper _mapper;


        public Handler(DataContext ctx, IMapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }

        public async Task<List<CasterProfileDto>> Handle(Query request, CancellationToken cancellationToken)
        {
           var profileDtos = await _ctx.CasterProfiles.Select(
                u => _mapper.Map<CasterProfile, CasterProfileDto>(u)).ToListAsync(cancellationToken);

           return profileDtos != null ? profileDtos : null;
        }
    }
    
}
