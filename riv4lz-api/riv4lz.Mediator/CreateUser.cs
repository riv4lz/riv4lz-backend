using MediatR;
using Microsoft.AspNetCore.Identity;
using riv4lz.dataAccess.Entities;
using riv4lz.Mediator.Dtos;

namespace riv4lz.Mediator;

public class CreateUser
{
    public class Command : IRequest
    {
        public RegisterUserDto RegisterUserDto { get; set; }
    }

    public class Handler : IRequestHandler<Command>
    {
        private readonly UserManager<IdentityUser<Guid>> _userManager;

        public Handler(UserManager<IdentityUser<Guid>> userManager)
        {
            _userManager = userManager;
        }

        public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
        {
            var user = new AppUser()
            {
                Id = new Guid(),
                Email = request.RegisterUserDto.Email
            };

            var result = await _userManager.CreateAsync(user, request.RegisterUserDto.Password);

            if (result.Succeeded)
            {
                return Unit.Value;
            }

            return Unit.Value;
        }
    }
}
