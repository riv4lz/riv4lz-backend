using MediatR;
using Microsoft.AspNetCore.Identity;
using riv4lz.core.Models;
using riv4lz.dataAccess.Entities;
using riv4lz.Mediator.Dtos;

namespace riv4lz.Mediator;

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
            var user = new AppUser()
            {
                Id = request.RegisterUserDto.Id,
                Email = request.RegisterUserDto.Email
            };

            var registerUserResult = await _userManager.CreateAsync(user, request.RegisterUserDto.Password);

            return registerUserResult.Succeeded && AddRole(user, request.UserType);
        }

        private bool AddRole(AppUser user, UserType requestUserType)
        {
            return requestUserType == UserType.caster ? 
                _userManager.AddToRoleAsync(user, UserType.caster.ToString()).Result.Succeeded : 
                _userManager.AddToRoleAsync(user, UserType.organisation.ToString()).Result.Succeeded;
        }
    }
}
