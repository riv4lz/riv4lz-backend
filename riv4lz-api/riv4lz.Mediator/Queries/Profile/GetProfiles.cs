using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using riv4lz.core.Enums;
using riv4lz.dataAccess;
using riv4lz.Mediator.Dtos.Profile;

namespace riv4lz.Mediator.Queries.Profile;

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
            var profiles = await _ctx.Profiles
                .Where(p => p.UserType == request.UserType)
                .Select(u => _mapper.Map<ProfileDto>(u))
                .ToListAsync(cancellationToken);

            if (profiles.IsNullOrEmpty())
                return null;

            return profiles;
        }
    }
}