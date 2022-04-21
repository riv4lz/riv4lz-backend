using AutoMapper;
using MediatR;
using riv4lz.dataAccess;
using riv4lz.dataAccess.Entities;
using riv4lz.Mediator.Dtos;

namespace riv4lz.Mediator.Commands.CasterCommands;

public class CreateCasterProfile
{
    public class Command : IRequest<bool>
    {
        public RegisterCasterProfileDto RegisterCasterProfileDto { get; set; }
    }
    
    public class Handler: IRequestHandler<Command, bool>
    {
        private readonly IMapper _mapper;
        private readonly CasterDbContext _ctx;

        public Handler(IMapper mapper, CasterDbContext ctx)
        {
            _mapper = mapper;
            _ctx = ctx;
        }

        public async Task<bool> Handle(Command request, CancellationToken cancellationToken)
        {
            await _ctx.CasterProfiles.AddAsync(
                _mapper.Map<RegisterCasterProfileDto, CasterProfileEntity>(request.RegisterCasterProfileDto), cancellationToken);

            var result = await _ctx.SaveChangesAsync(cancellationToken);

            return result > 0;
        }
    }
    

}