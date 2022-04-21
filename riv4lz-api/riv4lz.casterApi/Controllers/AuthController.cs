using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using riv4lz.casterApi.Dtos;
using riv4lz.casterApi.Services;
using riv4lz.core.Models;
using riv4lz.dataAccess.Entities;
using riv4lz.Mediator;
using riv4lz.Mediator.Dtos;

namespace riv4lz.casterApi.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser<Guid>> _userManager;
        private readonly SignInManager<IdentityUser<Guid>> _signInManager;
        private readonly TokenService _tokenService;
        private readonly IMediator _mediator;

        public AuthController(UserManager<IdentityUser<Guid>> userManager, 
            SignInManager<IdentityUser<Guid>> signInManager,
            TokenService tokenService, IMediator mediator)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
            _mediator = mediator;
        }

        [AllowAnonymous]
        [HttpPost(nameof(Login))]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);
            if (user == null)
            {
                return Unauthorized();
            }
            

            var result = await _signInManager
                .CheckPasswordSignInAsync(user, loginDto.Password, false);

            if (result.Succeeded)
            {
                return new UserDto()
                {
                    Id = user.Id,
                    Email = user.Email,
                    Token = _tokenService.CreateToken(user),
                };
            }

            return Unauthorized();
        }

        [AllowAnonymous]
        [HttpPost(nameof(RegisterCaster))]
        public async Task<ActionResult<UserDto>> RegisterCaster([FromBody] RegisterUserDto registerUserDto)
        {
            if (await IsEmailTaken(registerUserDto.Email))
            {
                return BadRequest("Email taken");
            }

            var result = await _mediator.Send(new CreateUser.Command
            {
                RegisterUserDto = registerUserDto, 
                UserType = UserType.caster
            });

            if (!result)
            {
                return BadRequest("Problem registering caster");
            }

            var userDto = await _mediator.Send(new FindUserByEmail.Query {Email = registerUserDto.Email});

            return userDto != null ? userDto : BadRequest("Problem registering caster");
        }

        [Authorize(Roles = "CasterProfile")]
        [HttpPost(nameof(RegisterCasterProfile))]
        public async Task<ActionResult<CasterDto>> RegisterCasterProfile([FromBody] RegisterUserDto registerUserDto)
        {
            return null;
        }

        [HttpGet(nameof(GetCurrentUser))]
        public async Task<ActionResult<UserDto>> GetCurrentUser()
        {
            return await _mediator.Send(new FindUserByEmail.Query {Email = User.FindFirstValue(ClaimTypes.Email)});
        }

        [HttpGet(nameof(IsEmailTaken))]
        public async Task<bool> IsEmailTaken(string email)
        {
            return await _mediator.Send(new IsEmailTaken.Query { Email = email});
        }
    }

    
}