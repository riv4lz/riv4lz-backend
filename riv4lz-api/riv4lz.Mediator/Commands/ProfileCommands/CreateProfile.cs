using AutoMapper;
using MediatR;
using riv4lz.dataAccess;
using riv4lz.Mediator.Dtos.Casters;
using Profile = riv4lz.core.Entities.Profile;

namespace riv4lz.Mediator.Commands.ProfileCommands;

public class CreateProfile
{
    public class Command : IRequest<bool>
    {
        public RegisterProfileDto RegisterProfileDto { get; set; }
    }
    
    public class Handler: IRequestHandler<Command, bool>
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
            await _ctx.Profiles.AddAsync(
                _mapper.Map<RegisterProfileDto, Profile>(request.RegisterProfileDto), cancellationToken);

            var result = await _ctx.SaveChangesAsync(cancellationToken);

            return result > 0;
        }
    }
}