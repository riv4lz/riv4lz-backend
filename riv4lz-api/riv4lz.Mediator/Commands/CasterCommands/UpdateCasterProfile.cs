using AutoMapper;
using MediatR;
using riv4lz.dataAccess;
using riv4lz.Mediator.Dtos.Casters;

namespace riv4lz.Mediator.Commands.CasterCommands;

public class UpdateCasterProfile
{
    public class Command : IRequest<bool>
    {
        public UpdateCasterProfileDto UpdateCasterProfileDto { get; set; }
    }
    
    public class Handler : BaseHandler, IRequestHandler<Command, bool>
    {
        public async Task<bool> Handle(Command request, CancellationToken cancellationToken)
        {
            var profile = await _ctx.CasterProfiles.FindAsync(
                request.UpdateCasterProfileDto.CasterId);
            
            if (profile == null)
            {
                return false;
            }
            
            _mapper.Map(request.UpdateCasterProfileDto, profile);
            
            var result = await _ctx.SaveChangesAsync(cancellationToken);
            
            return result > 0;
        }
    }
}