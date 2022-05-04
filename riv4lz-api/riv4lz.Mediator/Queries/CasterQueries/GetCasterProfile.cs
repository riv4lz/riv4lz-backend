using AutoMapper;
using MediatR;
using riv4lz.core.Entities;
using riv4lz.dataAccess;
using riv4lz.Mediator.Dtos.Casters;

namespace riv4lz.Mediator.Queries.CasterQueries;

public class GetCasterProfile
{
    public class Query : IRequest<CasterProfileDto>
    {
        public Guid CasterId { get; set; }
    }
    
    public class Handler : IRequestHandler<Query, CasterProfileDto>
    {
        private readonly IMapper _mapper;
        private readonly DataContext _ctx;

        public Handler(IMapper mapper, DataContext ctx)
        {
            _mapper = mapper;
            _ctx = ctx;
        }
        public async Task<CasterProfileDto> Handle(Query request, CancellationToken cancellationToken)
        {
           var entity = _ctx.CasterProfiles.FirstOrDefault(
                u => u.CasterId == request.CasterId);

           return entity != null ? _mapper.Map<CasterProfile, CasterProfileDto>(entity) : null;
        }
    }
    
}
