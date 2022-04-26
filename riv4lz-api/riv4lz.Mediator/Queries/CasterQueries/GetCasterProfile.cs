using AutoMapper;
using MediatR;
using riv4lz.dataAccess;
using riv4lz.dataAccess.Entities;
using riv4lz.Mediator.Dtos;
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
        private readonly DataContext _ctx;
        private readonly IMapper _mapper;


        public Handler(DataContext ctx, IMapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }

        public async Task<CasterProfileDto> Handle(Query request, CancellationToken cancellationToken)
        {
           var entity = _ctx.CasterProfiles.FirstOrDefault(
                u => u.CasterId == request.CasterId);

           return entity != null ? _mapper.Map<CasterProfile, CasterProfileDto>(entity) : null;
        }
    }
    
}
