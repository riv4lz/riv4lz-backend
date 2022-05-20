using MediatR;
using riv4lz.core.Enums;
using riv4lz.dataAccess;
using riv4lz.Mediator.Dtos.Events;

namespace riv4lz.Mediator.Commands.Offers;

public class RejectOffer
{
    public class Command : IRequest<bool>
    {
        public UpdateOfferDto UpdateOfferDto { get; set; }
    }

    public class Handler : IRequestHandler<Command, bool>
    {
        private readonly DataContext _ctx;

        public Handler(DataContext ctx)
        {
            _ctx = ctx;
        }
        public async Task<bool> Handle(Command request, CancellationToken cancellationToken)
        {
            var offer = await _ctx.Offers
                .FindAsync(request.UpdateOfferDto.Id, cancellationToken);

            if (offer is null)
                return false;
                
            offer.OfferStatus = OfferStatus.Rejected;
            var result = await _ctx.SaveChangesAsync(cancellationToken);
            
            return result > 0;
        }
    }
}