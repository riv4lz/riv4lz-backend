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
        private readonly DataContext _ctx;
        private readonly IMapper _mapper;


        public Handler(DataContext ctx, IMapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }

        public async Task<OfferDto?> Handle(Query request, CancellationToken cancellationToken)
        {
            var entity = await _ctx.Offers.FirstOrDefaultAsync(e => e.Id == request.OfferId, cancellationToken);
            
            return entity == null ? null : _mapper.Map<OfferDto>(entity);
        }
    }
}