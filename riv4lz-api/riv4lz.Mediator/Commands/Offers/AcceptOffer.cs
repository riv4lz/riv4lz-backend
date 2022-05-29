using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using riv4lz.core.Enums;
using riv4lz.dataAccess;
using riv4lz.Mediator.Dtos.Events;

namespace riv4lz.Mediator.Commands.Offers;

public class AcceptOffer
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
            await using var dbTransaction = await _ctx.Database.BeginTransactionAsync(cancellationToken);
            try
            {
                var offer = await _ctx.Offers
                    .Include(o => o.Event)
                    .FirstOrDefaultAsync(o => o.Id == request.UpdateOfferDto.Id, cancellationToken);

                if (offer is null)
                    return false;
                
                
                offer.OfferStatus = OfferStatus.Closed;
                
                var result = await RejectOtherOffers(request, cancellationToken);
                /*if (!result)
                {
                    await dbTransaction.RollbackAsync(cancellationToken);
                    return false;
                }*/
                
                offer.Event.EventStatus = EventStatus.Closed;
                await _ctx.SaveChangesAsync(cancellationToken);

                await dbTransaction.CommitAsync(cancellationToken);
                return true;
            }
            catch (Exception e)
            {
                await dbTransaction.RollbackAsync(cancellationToken);
                Console.WriteLine(e);
                return false;
            }
        }

        private async Task<int> RejectOtherOffers(Command request, CancellationToken cancellationToken)
        {
            var offers = await _ctx.Offers
                .Where(o => o.Id != request.UpdateOfferDto.Id)
                .ToListAsync(cancellationToken);

            if (offers.IsNullOrEmpty())
                return 0;

            foreach (var o in offers)
                o.OfferStatus = OfferStatus.Rejected;

            return await _ctx.SaveChangesAsync(cancellationToken);
        }
    }
}