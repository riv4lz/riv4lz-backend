using MediatR;
using FluentValidation;
using riv4lz.dataAccess;

namespace riv4lz.Mediator.Commands.CasterCommands;

public class CommandTemplate
{
    public class Command: IRequest<bool>
    {
        public string Body { get; set; }
        public string UserName { get; set; }
    }

    public class CommandValidator : AbstractValidator<Command>
    {
        public CommandValidator()
        {
            RuleFor(x => x.Body).NotEmpty();
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