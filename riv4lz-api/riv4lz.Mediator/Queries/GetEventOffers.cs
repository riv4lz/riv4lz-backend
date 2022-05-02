using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using riv4lz.core.Models;
using riv4lz.dataAccess;
using riv4lz.Mediator.Dtos;

namespace riv4lz.Mediator.Queries;

public class GetEventOffers
{
    public class Query : IRequest<List<OfferDto>?>
    {
        public Guid EventId { get; set; }
    }
    
    public class Handler : IRequestHandler<Query, List<OfferDto>?>
    {
        private readonly DataContext _ctx;
        private readonly IMapper _mapper;


        public Handler(DataContext ctx, IMapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }

        public async Task<List<OfferDto>?> Handle(Query request, CancellationToken cancellationToken)
        {
            var eventOffers = await _ctx.Offers.Where(x => x.EventId == request.EventId)
                .Select(e => _mapper.Map<OfferDto>(e)).ToListAsync(cancellationToken);

            return eventOffers.IsNullOrEmpty() ? null : eventOffers;

        }
    }
}