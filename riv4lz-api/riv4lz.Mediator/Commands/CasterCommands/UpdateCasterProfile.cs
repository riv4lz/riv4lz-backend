using AutoMapper;
using MediatR;
using riv4lz.dataAccess;
using riv4lz.Mediator.Dtos;
using riv4lz.Mediator.Dtos.Casters;

namespace riv4lz.Mediator.Commands.CasterCommands;

public class UpdateCasterProfile
{
    public class Command : IRequest<bool>
    {
        public UpdateCasterProfileDto UpdateCasterProfileDto { get; set; }
    }
    
    public class Handler : IRequestHandler<Command, bool>
    {
        private readonly DataContext _ctx;
        private readonly IMapper _mapper;

        public Handler(DataContext ctx, IMapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }

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