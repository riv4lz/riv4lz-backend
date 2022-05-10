using AutoMapper;
using MediatR;
using riv4lz.core.Entities;
using riv4lz.dataAccess;
using riv4lz.Mediator.Dtos.Casters;
using Profile = riv4lz.core.Entities.Profile;

namespace riv4lz.Mediator.Queries.CasterQueries;

public class GetProfile
{
    public class Query : IRequest<ProfileDto>
    {
        public Guid Id { get; set; }
    }
    
    public class Handler : IRequestHandler<Query, ProfileDto>
    {
        private readonly IMapper _mapper;
        private readonly DataContext _ctx;

        public Handler(IMapper mapper, DataContext ctx)
        {
            _mapper = mapper;
            _ctx = ctx;
        }
        public async Task<ProfileDto> Handle(Query request, CancellationToken cancellationToken)
        {
           var entity = _ctx.Profiles.FirstOrDefault(
                u => u.Id == request.Id);

           return entity != null ? _mapper.Map<Profile, ProfileDto>(entity) : null;
        }
    }
    
}
