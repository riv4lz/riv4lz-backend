using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using riv4lz.dataAccess;
using riv4lz.Mediator.Dtos.Events;

namespace riv4lz.Mediator.Queries.EventQueries;

public class GetEventOffers
{
    public class Query : IRequest<List<OfferDto>?>
    {
        public Guid EventId { get; set; }
    }
    
    public class Handler : IRequestHandler<Query, List<OfferDto>?>
    {
        private readonly IMapper _mapper;
        private readonly DataContext _ctx;

        public Handler(IMapper mapper, DataContext ctx)
        {
            _mapper = mapper;
            _ctx = ctx;
        }
        public async Task<List<OfferDto>?> Handle(Query request, CancellationToken cancellationToken)
        {
            var eventOffers = await _ctx.Offers
                .Where(x => x.EventId == request.EventId)
                .Include(o => o.Caster)
                .Select(e => _mapper.Map<OfferDto>(e))
                .ToListAsync(cancellationToken);

            if (eventOffers.IsNullOrEmpty())
                return null;

            return eventOffers;
        }
    }
}