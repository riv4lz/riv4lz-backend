using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using riv4lz.core.Enums;
using riv4lz.dataAccess;
using riv4lz.Mediator.Dtos.Profile;
using riv4lz.Mediator.Helpers;

namespace riv4lz.Mediator.Queries.Profile;

public class GetAllProfiles
{
    public class Query : IRequest<List<ProfileDto>>
    {
    }

    public class Handler : IRequestHandler<Query, List<ProfileDto>>
    {
        private readonly IMapper _mapper;
        private readonly DataContext _ctx;
        private readonly RedisInstance _redis;

        public Handler(IMapper mapper, DataContext ctx, RedisInstance redis)
        {
            _mapper = mapper;
            _ctx = ctx;
            _redis = redis;
        }

        public async Task<List<ProfileDto>> Handle(Query request, CancellationToken cancellationToken)
        {
            var cachedProfiles = await _redis.Get<List<ProfileDto>>("profiles");

            if (cachedProfiles.IsNullOrEmpty())
            {
                var profiles = await _ctx.Profiles
                    .Select(u => _mapper.Map<ProfileDto>(u))
                    .ToListAsync(cancellationToken);

                if (profiles.IsNullOrEmpty())
                    return null;
                
                _redis.Set("profiles", profiles);

                return profiles;
            }
            Console.WriteLine("Using cached profiles");
            return cachedProfiles;
        }
    }
}
