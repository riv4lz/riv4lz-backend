using AutoMapper;
using MediatR;
using riv4lz.dataAccess;
using riv4lz.Mediator.Dtos;

namespace riv4lz.Mediator.Commands;

public class UpdateOfferStatus
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
            var offer = await _ctx.Offers.FindAsync(request.UpdateOfferDto.Id);

            if (offer != null)
            {
                offer.OfferStatus = request.UpdateOfferDto.OfferStatus;
            }

            var result = await _ctx.SaveChangesAsync(cancellationToken);
            
            return result > 0;
        }
    }
}