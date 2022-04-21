using AutoMapper;
using MediatR;
using riv4lz.core.IServices;
using riv4lz.core.Models;
using riv4lz.dataAccess;
using riv4lz.dataAccess.Entities;
using riv4lz.domain.IRepositories;
using riv4lz.Mediator.Dtos;

namespace riv4lz.Mediator;

public class CreateCasterProfile
{
    public class Command : IRequest<CasterProfileDto>
    {
        public RegisterCasterProfileDto RegisterCasterProfileDto { get; set; }
    }
    
    public class Handler: IRequestHandler<Command, CasterProfileDto>
    {
        private readonly IMapper _mapper;
        private readonly CasterDbContext _ctx;

        public Handler(IMapper mapper, CasterDbContext ctx)
        {
            _mapper = mapper;
            _ctx = ctx;
        }

        public async Task<CasterProfileDto> Handle(Command request, CancellationToken cancellationToken)
        {
            var entity = _ctx.CasterProfiles.Add(
                _mapper.Map<RegisterCasterProfileDto, CasterProfileEntity>(request.RegisterCasterProfileDto)).Entity;

            return entity != null ? _mapper.Map<CasterProfileEntity, CasterProfileDto>(entity) : null;
        }
    }
    

}