using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using riv4lz.dataAccess;
using riv4lz.Mediator.Dtos.Casters;

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
           var entity = await _ctx.Profiles.FirstOrDefaultAsync(
                u => u.Id == request.Id, cancellationToken);

           return entity is not null ? _mapper.Map<ProfileDto>(entity) : null;
        }
    }
    
}
