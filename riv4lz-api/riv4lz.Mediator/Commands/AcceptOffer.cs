using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using riv4lz.core.Enums;
using riv4lz.dataAccess;
using riv4lz.Mediator.Dtos.Events;

namespace riv4lz.Mediator.Commands;

public class AcceptOffer
{
    public class Command : IRequest<bool>
    {
        public UpdateOfferDto UpdateOfferDto { get; set; }
    }

    public class Handler : IRequestHandler<Command, bool>
    {
        private readonly IMapper _mapper;
        private readonly DataContext _ctx;

        public Handler(IMapper mapper, DataContext ctx)
        {
            _mapper = mapper;
            _ctx = ctx;
        }
        public async Task<bool> Handle(Command request, CancellationToken cancellationToken)
        {
            
            await using (var dbTransaction = await _ctx.Database.BeginTransactionAsync(cancellationToken))
            {
                try
                {
                    // Set accepted offer status to CLOSED.
                    var offer = await _ctx.Offers.Include(o => o.Event).FirstOrDefaultAsync(o => o.Id == request.UpdateOfferDto.Id);

                    if (offer != null)
                    {
                        offer.OfferStatus = OfferStatus.Closed;
                    }

                    await _ctx.SaveChangesAsync(cancellationToken);
                    
                    
                    // Set all other offers' status to REJECTED.
                    var offers = await _ctx.Offers
                        .Where(o => o.Id != request.UpdateOfferDto.Id)
                        .ToListAsync(cancellationToken);
                
                    foreach (var o in offers)
                    {
                        o.OfferStatus = OfferStatus.Rejected;
                    }
                    
                    // TODO REMOVE in refactoring
                    // Set event status to CLOSED.
                    offer.Event.EventStatus = EventStatus.CLOSED;
                    
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
        }
    }
}