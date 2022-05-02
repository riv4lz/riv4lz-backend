using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using riv4lz.dataAccess;
using riv4lz.Mediator.Dtos;

namespace riv4lz.Mediator.Queries;

public class GetEventOffers
{
    public class Query : IRequest<List<OfferDto>?>
    {
        public Guid EventId { get; set; }
    }
    
    public class Handler : BaseHandler, IRequestHandler<Query, List<OfferDto>?>
    {
        public async Task<List<OfferDto>?> Handle(Query request, CancellationToken cancellationToken)
        {
            var eventOffers = await _ctx.Offers.Where(x => x.EventId == request.EventId)
                .Include(o => o.Caster)
                .Select(e => _mapper.Map<OfferDto>(e)).ToListAsync(cancellationToken);

            return eventOffers.IsNullOrEmpty() ? null : eventOffers;

        }
    }
}