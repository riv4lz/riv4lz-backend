using MediatR;
using Microsoft.AspNetCore.Identity;
using riv4lz.Mediator.Dtos;

namespace riv4lz.Mediator.Commands.Auth;

public class UpdatePassword
{
    public class Command : IRequest<bool>
    {
        public UpdatePasswordDto UpdatePasswordDto { get; set; }
    }

    public class Handler : IRequestHandler<Command, bool>
    {
        private readonly UserManager<IdentityUser<Guid>> _userManager;
        private readonly SignInManager<IdentityUser<Guid>> _signInManager;

        public Handler(UserManager<IdentityUser<Guid>> userManager, SignInManager<IdentityUser<Guid>> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<bool> Handle(Command request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.UpdatePasswordDto.UserId.ToString());
            if (user == null)
            {
                return false;
            }
            
            var result = await _userManager.ChangePasswordAsync(
                user, request.UpdatePasswordDto.OldPassword, request.UpdatePasswordDto.NewPassword);
            
            return result.Succeeded;
        }
    }
}