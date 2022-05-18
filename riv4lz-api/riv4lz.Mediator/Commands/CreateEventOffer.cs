using AutoMapper;
using MediatR;
using riv4lz.core.Entities;
using riv4lz.dataAccess;
using riv4lz.Mediator.Dtos.Events;

namespace riv4lz.Mediator.Commands;

public class CreateEventOffer
{
    public class Command : IRequest<bool>
    {
        public CreateOfferDto CreateOfferDto { get; set; }
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
            await _ctx.Offers.AddAsync(_mapper.Map<Offer>(request.CreateOfferDto), cancellationToken);
            
            return await _ctx.SaveChangesAsync(cancellationToken) > 0;
        }
    }
}