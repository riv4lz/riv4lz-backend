using AutoMapper;
using MediatR;
using riv4lz.core.Models;
using riv4lz.dataAccess;
using riv4lz.Mediator.Dtos;

namespace riv4lz.Mediator.Commands;

public class RejectOffer
{
    public class Command : IRequest<bool>
    {
        public UpdateOfferDto UpdateOfferDto { get; set; }
    }

    public class Handler : IRequestHandler<Command, bool>
    {
        private readonly DataContext _ctx;
        private readonly IMapper _mapper;

        public Handler(DataContext ctx, IMapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }

        public async Task<bool> Handle(Command request, CancellationToken cancellationToken)
        {
            var offer = await _ctx.Offers.FindAsync(request.UpdateOfferDto.Id);

            if (offer != null)
            {
                offer.OfferStatus = OfferStatus.REJECTED;
            }

            return await _ctx.SaveChangesAsync(cancellationToken) > 0;
        }
    }
}