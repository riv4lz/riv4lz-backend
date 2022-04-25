using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using riv4lz.dataAccess;
using riv4lz.Mediator.Dtos;

namespace riv4lz.Mediator.Commands.CasterCommands;

public class UpdateCasterProfile
{
    public class Command : IRequest<bool>
    {
        public UpdateCasterProfileDto UpdateCasterProfileDto { get; set; }
    }
    
    public class Handler : IRequestHandler<Command, bool>
    {
        private readonly CasterDbContext _ctx;
        private readonly IMapper _mapper;

        public Handler(CasterDbContext ctx, IMapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }

        public async Task<bool> Handle(Command request, CancellationToken cancellationToken)
        {
            var profile = await _ctx.CasterProfiles.FindAsync(
                request.UpdateCasterProfileDto.CasterId, cancellationToken);
            
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