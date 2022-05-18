using MediatR;
using Microsoft.AspNetCore.Identity;
using riv4lz.core.Enums;
using riv4lz.Mediator.Dtos.Auth;

namespace riv4lz.Mediator.Commands.Auth;

public class CreateUser
{
    public class Command : IRequest<bool>
    {
        public RegisterUserDto RegisterUserDto { get; set; }
        public UserType UserType { get; set; }
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
            var user = new IdentityUser<Guid>()
            {
                Id = request.RegisterUserDto.Id,
                Email = request.RegisterUserDto.Email,
                UserName = request.RegisterUserDto.Email
            };

            var registerUserResult = await _userManager.CreateAsync(user, request.RegisterUserDto.Password);

            return registerUserResult.Succeeded && AddRole(user, request.UserType);
        }

        private bool AddRole(IdentityUser<Guid> user, UserType requestUserType)
        {
            return requestUserType == UserType.Caster ? 
                _userManager.AddToRoleAsync(user, UserType.Caster.ToString()).Result.Succeeded : 
                _userManager.AddToRoleAsync(user, UserType.Organisation.ToString()).Result.Succeeded;
        }
    }
}
