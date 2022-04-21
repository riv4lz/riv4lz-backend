using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using riv4lz.core.Models;
using riv4lz.Mediator;
using riv4lz.Mediator.Commands.CasterCommands;
using riv4lz.Mediator.Dtos;
using riv4lz.Mediator.Queries.CasterQueries;

namespace riv4lz.casterApi.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [AllowAnonymous]
        [HttpPost(nameof(Login))]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            var user = await _mediator.Send(new AuthenticateUser.Query {LoginDto = loginDto});
            if (user == null)
            {
                return Unauthorized();
            }

            return user;
        }

        [AllowAnonymous]
        [HttpPost(nameof(RegisterCaster))]
        public async Task<ActionResult<UserDto>> RegisterCaster(RegisterUserDto registerUserDto)
        {
            return await RegisterUser(registerUserDto, UserType.caster);
        }

        [AllowAnonymous]
        [HttpPost(nameof(RegisterOrganisation))]
        public async Task<ActionResult<UserDto>> RegisterOrganisation(RegisterUserDto registerUserDto)
        {
            return await RegisterUser(registerUserDto, UserType.organisation);
        }

        [HttpGet(nameof(GetCurrentUser))]
        public async Task<ActionResult<UserDto>> GetCurrentUser()
        {
            return await _mediator.Send(new FindUserByEmail.Query {Email = User.FindFirstValue(ClaimTypes.Email)});
        }

        [AllowAnonymous]
        [HttpGet(nameof(IsEmailTaken))]
        public async Task<bool> IsEmailTaken(string email)
        {
            return await _mediator.Send(new IsEmailTaken.Query { Email = email});
        }
        
        private async Task<ActionResult<UserDto>> RegisterUser(RegisterUserDto registerUserDto, UserType userType)
        {
            if (await IsEmailTaken(registerUserDto.Email))
            {
                return BadRequest("Email taken");
            }

            var result = await _mediator.Send(new CreateUser.Command
            {
                RegisterUserDto = registerUserDto,
                UserType = userType
            });

            if (!result)
            {
                return BadRequest("Problem registering user");
            }

            var userDto = await _mediator.Send(new FindUserByEmail.Query {Email = registerUserDto.Email});

            return userDto != null ? userDto : BadRequest("Problem registering user");
        }
    }

    
}