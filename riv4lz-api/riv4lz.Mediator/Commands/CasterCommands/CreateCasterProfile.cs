using AutoMapper;
using MediatR;
using riv4lz.dataAccess;
using riv4lz.dataAccess.Entities;
using riv4lz.Mediator.Dtos.Casters;

namespace riv4lz.Mediator.Commands.CasterCommands;

public class CreateCasterProfile
{
    public class Command : IRequest<bool>
    {
        public RegisterCasterProfileDto RegisterCasterProfileDto { get; set; }
    }
    
    public class Handler: BaseHandler, IRequestHandler<Command, bool>
    {
        public async Task<bool> Handle(Command request, CancellationToken cancellationToken)
        {
            await _ctx.CasterProfiles.AddAsync(
                _mapper.Map<RegisterCasterProfileDto, CasterProfile>(request.RegisterCasterProfileDto), cancellationToken);

            var result = await _ctx.SaveChangesAsync(cancellationToken);

            return result > 0;
        }
    }
}