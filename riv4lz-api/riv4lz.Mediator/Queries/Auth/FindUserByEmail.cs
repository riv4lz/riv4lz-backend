using MediatR;
using Microsoft.AspNetCore.Identity;
using riv4lz.Mediator.Dtos.Auth;
using riv4lz.Mediator.Helpers;

namespace riv4lz.Mediator.Queries.Auth;

public class FindUserByEmail
{
    public class Query : IRequest<UserDto>
    {
        public string Email { get; set; }
    }
    
    public class Handler : IRequestHandler<Query, UserDto>
    {
        private readonly UserManager<IdentityUser<Guid>> _userManager;
        private readonly TokenHelper _tokenHelper;

        public Handler(UserManager<IdentityUser<Guid>> userManager, TokenHelper tokenHelper)
        {
            _userManager = userManager;
            _tokenHelper = tokenHelper;
        }

        public async Task<UserDto> Handle(Query request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            // test tosee ttt
            var userDto = new UserDto()
            {
                Id = user.Id,
                Email = user.Email,
                Token = _tokenHelper.CreateToken(user)
            };

            return user != null ? userDto : null;
        }
    }
}