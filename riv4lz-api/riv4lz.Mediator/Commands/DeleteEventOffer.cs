using MediatR;
using riv4lz.dataAccess;

namespace riv4lz.Mediator.Commands;

public class DeleteEventOffer
{
    public class Command : IRequest<bool>
    {
        public Guid OfferId { get; set; }
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
                .FindAsync(request.OfferId, cancellationToken);

            if (offer is null)
                return false;
            
            _ctx.Offers.Remove(offer);
            var result = await _ctx.SaveChangesAsync(cancellationToken);
            
            return result > 0;
        }
    }
}