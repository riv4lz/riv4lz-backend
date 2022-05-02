using FluentValidation;
using MediatR;
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
        private readonly DataContext _ctx;

        public Handler(DataContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<bool> Handle(Command request, CancellationToken cancellationToken)
        {
            return false;
        }
    }
}