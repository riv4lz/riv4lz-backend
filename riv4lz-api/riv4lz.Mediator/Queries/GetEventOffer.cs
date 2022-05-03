using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using riv4lz.dataAccess;
using riv4lz.Mediator.Dtos;

namespace riv4lz.Mediator.Queries;

public class GetEventOffer
{
    public class Query : IRequest<OfferDto?>
    {
        public Guid OfferId { get; set; }
    }
    
    public class Handler : IRequestHandler<Query, OfferDto?>
    {
        private readonly IMapper _mapper;
        private readonly DataContext _ctx;

        public Handler(IMapper mapper, DataContext ctx)
        {
            _mapper = mapper;
            _ctx = ctx;
        }
        public async Task<OfferDto?> Handle(Query request, CancellationToken cancellationToken)
        {
            var entity = await _ctx.Offers
                .Include(o => o.Caster)
                .FirstOrDefaultAsync(e => e.Id == request.OfferId, cancellationToken);
            
            return entity == null ? null : _mapper.Map<OfferDto>(entity);
        }
    }
}