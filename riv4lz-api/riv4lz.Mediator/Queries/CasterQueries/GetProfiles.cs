using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using riv4lz.core.Models;
using riv4lz.dataAccess;
using riv4lz.Mediator.Dtos.Casters;
using Profile = riv4lz.core.Entities.Profile;

namespace riv4lz.Mediator.Queries.CasterQueries;

public class GetProfiles
{
    public class Query : IRequest<List<ProfileDto>>
    {
        public UserType UserType { get; set; }
    }
    
    public class Handler : IRequestHandler<Query, List<ProfileDto>>
    {
        private readonly IMapper _mapper;
        private readonly DataContext _ctx;

        public Handler(IMapper mapper, DataContext ctx)
        {
            _mapper = mapper;
            _ctx = ctx;
        }
        public async Task<List<ProfileDto>> Handle(Query request, CancellationToken cancellationToken)
        {
           var profileDtos = await _ctx.Profiles.Where(p => p.UserType == request.UserType)
               .Select(
                u => _mapper.Map<Profile, ProfileDto>(u)).ToListAsync(cancellationToken);

           return profileDtos != null ? profileDtos : null;
        }
    }
    
}
