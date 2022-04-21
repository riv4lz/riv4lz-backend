using MediatR;
using Microsoft.AspNetCore.Identity;
using riv4lz.casterApi.Services;
using riv4lz.Mediator.Dtos;

namespace riv4lz.Mediator;

public class FindUserByEmail
{
    public class Query : IRequest<UserDto>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
    
    public class Handler : IRequestHandler<Query, UserDto>
    {
        private readonly UserManager<IdentityUser<Guid>> _userManager;
        private readonly TokenService _tokenService;

        public Handler(UserManager<IdentityUser<Guid>> userManager, TokenService tokenService)
        {
            _userManager = userManager;
            _tokenService = tokenService;
        }

        public async Task<UserDto> Handle(Query request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            
            var userDto = new UserDto()
            {
                Id = user.Id,
                Email = user.Email,
                Token = _tokenService.CreateToken(user)
            };

            return user != null ? userDto : null;
        }
    }
}