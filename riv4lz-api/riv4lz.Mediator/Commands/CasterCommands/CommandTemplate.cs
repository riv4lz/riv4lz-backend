using MediatR;
using riv4lz.Mediator.Dtos;
using System;
using AutoMapper;
using FluentValidation;
using riv4lz.dataAccess;
using riv4lz.domain;

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
        private readonly CasterDbContext _ctx;

        public Handler(CasterDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<bool> Handle(Command request, CancellationToken cancellationToken)
        {
            var comment = new Comment()
            {
                Body = request.Body,
                UserName = request.UserName
            };

            await _ctx.Comments.AddAsync(comment, cancellationToken);
            var result = await _ctx.SaveChangesAsync(cancellationToken) > 0;

            return result;
        }
    }
}