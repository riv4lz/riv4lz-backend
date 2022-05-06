using AutoMapper;
using FluentValidation;
using MediatR;
using riv4lz.core.Entities;
using riv4lz.dataAccess;
using riv4lz.Mediator.Dtos;

namespace riv4lz.Mediator.Commands.Chat;

public class CreateMessage
{
    public class Command: IRequest<bool>
    {
        public CreateMessageDto CreateMessageDto { get; set; }
    }

    public class CommandValidator : AbstractValidator<Command>
    {
        public CommandValidator()
        {
            RuleFor(x => x.CreateMessageDto.Text).NotEmpty();
        }
    }
    
    public class Handler: IRequestHandler<Command, bool>
    {
        private readonly ChatContext _ctx;
        private readonly IMapper _mapper;

        public Handler(ChatContext ctx, IMapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }

        public async Task<bool> Handle(Command request, CancellationToken cancellationToken)
        {
            var messageEntity = _mapper.Map<Message>(request.CreateMessageDto);
            await _ctx.Messages.AddAsync(messageEntity, cancellationToken);
            return await _ctx.SaveChangesAsync(cancellationToken) > 0;
        }
    }
}