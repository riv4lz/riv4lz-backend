using MediatR;
using Microsoft.AspNetCore.Identity;
using riv4lz.Mediator.Dtos;
using riv4lz.Mediator.Dtos.Auth;

namespace riv4lz.Mediator.Commands.Auth;

public class UpdateEmail
{
    public class Command : IRequest<bool>
    {
        public UpdateEmailDto UpdateEmailDto { get; set; }
    }

    public class Handler : IRequestHandler<Command, bool>
    {
        private readonly UserManager<IdentityUser<Guid>> _userManager;

        public Handler(UserManager<IdentityUser<Guid>> userManager)
        {
            _userManager = userManager;
        }

        public async Task<bool> Handle(Command request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.UpdateEmailDto.UserId.ToString());
            if (user == null)
            {
                return false;
            }

            user.Email = request.UpdateEmailDto.Email;
            var result = await _userManager.UpdateAsync(user);

            return result.Succeeded;
        }
    }
}