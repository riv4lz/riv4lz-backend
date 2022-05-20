using AutoMapper;
using MediatR;
using riv4lz.dataAccess;
using riv4lz.Mediator.Dtos.Profile;

namespace riv4lz.Mediator.Commands.Profile;

public class UpdateProfile
{
    public class Command : IRequest<bool>
    {
        public UpdateProfileDto UpdateProfileDto { get; set; }
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
            var profile = await _ctx.Profiles
                .FindAsync(request.UpdateProfileDto.Id);
            
            if (profile == null)
                return false;
            
            _mapper.Map(request.UpdateProfileDto, profile);
            
            var result = await _ctx.SaveChangesAsync(cancellationToken);
            
            return result > 0;
        }
    }
}