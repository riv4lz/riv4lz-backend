using AutoMapper;
using riv4lz.dataAccess;
using riv4lz.dataAccess.Entities;
using riv4lz.Mediator.Dtos;

namespace riv4lz.Mediator.Queries;

using MediatR;


public class GetCasterProfile
{
    public class Query : IRequest<CasterProfileDto>
    {
        public Guid CasterId { get; set; }
    }
    
    public class Handler : IRequestHandler<Query, CasterProfileDto>
    {
        private readonly CasterDbContext _ctx;
        private readonly IMapper _mapper;


        public Handler(CasterDbContext ctx, IMapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }

        public async Task<CasterProfileDto> Handle(Query request, CancellationToken cancellationToken)
        {
           var entity = _ctx.CasterProfiles.FirstOrDefault(
                u => u.CasterId == request.CasterId);

           return entity != null ? _mapper.Map<CasterProfileEntity, CasterProfileDto>(entity) : null;
        }
    }
    
}
