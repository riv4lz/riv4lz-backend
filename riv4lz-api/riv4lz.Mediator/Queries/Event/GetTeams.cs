using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using riv4lz.dataAccess;
using riv4lz.Mediator.Dtos;
using riv4lz.Mediator.Dtos.Events;

namespace riv4lz.Mediator.Queries.Event;

public class GetTeams
{
    public class Query : IRequest<List<TeamDto>>
    {
    }
    
    public class Handler : IRequestHandler<Query, List<TeamDto>>
    {
        private readonly DataContext _ctx;
        private readonly IMapper _mapper;

        public Handler(DataContext ctx, IMapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }

        public async Task<List<TeamDto>> Handle(Query request, CancellationToken cancellationToken)
        {
            var teams = await _ctx.Teams
                .Select(te => _mapper.Map<TeamDto>(te))
                .ToListAsync(cancellationToken);

            if (teams.IsNullOrEmpty())
                return null;

            return teams;
        }
    }
}