using MediatR;
using Microsoft.AspNetCore.Identity;
using riv4lz.Mediator.Dtos.Auth;
using riv4lz.Mediator.Helpers;

namespace riv4lz.Mediator.Queries.Auth;

public class AuthenticateUser
{
    public class Query : IRequest<UserDto>
    {
        public LoginDto LoginDto { get; set; }
    }
    
    public class Handler : IRequestHandler<Query, UserDto>
    {
        private readonly UserManager<IdentityUser<Guid>> _userManager;
        private readonly TokenHelper _tokenHelper;
        private readonly SignInManager<IdentityUser<Guid>> _signInManager;

        public Handler(UserManager<IdentityUser<Guid>> userManager, TokenHelper tokenHelper,
            SignInManager<IdentityUser<Guid>> signInManager)
        {
            _userManager = userManager;
            _tokenHelper = tokenHelper;
            _signInManager = signInManager;
        }

        public async Task<UserDto> Handle(Query request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.LoginDto.Email);
            
            if (user == null)
            {
                return null;
            }
            var result = await _signInManager
                .CheckPasswordSignInAsync(user, request.LoginDto.Password, false);
            
            if (result.Succeeded)
            {
                return new UserDto()
                {
                    Id = user.Id,
                    Email = user.Email,
                    Token = _tokenHelper.CreateToken(user),
                };
            }
            return null;
        }
    }
}