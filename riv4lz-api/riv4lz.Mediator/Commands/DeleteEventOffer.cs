using AutoMapper;
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
        private readonly IMapper _mapper;
        private readonly DataContext _ctx;

        public Handler(IMapper mapper, DataContext ctx)
        {
            _mapper = mapper;
            _ctx = ctx;
        }
        public async Task<bool> Handle(Command request, CancellationToken cancellationToken)
        {
            var offer = await _ctx.Offers.FindAsync(request.OfferId, cancellationToken);

            if (offer != null)
            {
                _ctx.Offers.Remove(offer);
            }
            
            return await _ctx.SaveChangesAsync(cancellationToken) > 0;
        }
    }
}