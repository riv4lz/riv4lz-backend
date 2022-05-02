using AutoMapper;
using MediatR;
using riv4lz.dataAccess;
using riv4lz.dataAccess.Entities;
using riv4lz.Mediator.Dtos;

namespace riv4lz.Mediator.Commands;

public class CreateEventOffer
{
    public class Command : IRequest<bool>
    {
        public CreateOfferDto CreateOfferDto { get; set; }
    }

    public class Handler : BaseHandler, IRequestHandler<Command, bool>
    {
        public async Task<bool> Handle(Command request, CancellationToken cancellationToken)
        {
            await _ctx.Offers.AddAsync(_mapper.Map<Offer>(request.CreateOfferDto), cancellationToken);
            
            return await _ctx.SaveChangesAsync(cancellationToken) > 0;
        }
    }
}