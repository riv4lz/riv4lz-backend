using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using riv4lz.casterApi.Interfaces;
using riv4lz.core.Enums;
using riv4lz.Mediator.Commands.Auth;
using riv4lz.Mediator.Dtos.Auth;
using riv4lz.Mediator.Dtos.Chat;
using riv4lz.Mediator.Queries.Auth;
using riv4lz.Mediator.Queries.Chat;

namespace riv4lz.casterApi.Controllers
{
    
    public class AuthController : BaseController, IAuthController
    {
        [AllowAnonymous]
        [HttpPost(nameof(Login))]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            var user = await Mediator.Send(new AuthenticateUser.Query {LoginDto = loginDto});
            
            if (user is null)
                return Unauthorized(false);
            
            return Ok(user);
        }

        [HttpPut(nameof(UpdatePassword))]
        public async Task<ActionResult> UpdatePassword(UpdatePasswordDto updatePasswordDto)
        {
            var result = await Mediator
                .Send(new UpdatePassword.Command {UpdatePasswordDto = updatePasswordDto});

            if (!result)
                return BadRequest("Failed to update password");

            return Ok("Password updated");
        }

        [HttpPut(nameof(UpdateEmail))]
        public async Task<ActionResult> UpdateEmail(UpdateEmailDto updateEmailDto)
        {
            var emailTaken = await Mediator.Send(new IsEmailTaken.Query {Email = updateEmailDto.Email});
            
            if (emailTaken) 
                return BadRequest("Email is already taken");
            
            var result = await Mediator
                .Send(new UpdateEmail.Command {UpdateEmailDto = updateEmailDto});

            if (!result) 
                return BadRequest("Failed to update email");
            
            return Ok("Email updated");
        }
        
        [HttpPut(nameof(UpdateUsername))]
        public async Task<ActionResult> UpdateUsername(UpdateUsernameDto updateEmailDto)
        {
            var usernameTaken = await Mediator.Send(
                new IsUsernameTaken.Query {Username = updateEmailDto.Username});

            if (usernameTaken)
                return BadRequest("Username is already taken");
            
            
            var result = await Mediator
                .Send(new UpdateUsername.Command {UpdateUsernameDto = updateEmailDto});

            if (!result)
                return BadRequest("Failed to update username");

            return Ok("Username updated");
        }

        [HttpGet(nameof(GetCurrentUser))]
        public async Task<ActionResult<UserDto>> GetCurrentUser()
        {
            var user = await Mediator
                .Send(new FindUserByEmail.Query {Email = User.FindFirstValue(ClaimTypes.Email)});

            if (user is null)
                return Unauthorized();
            
            return Ok(user);
        }

        [AllowAnonymous]
        [HttpGet(nameof(IsEmailTaken))]
        public async Task<bool> IsEmailTaken(string email)
        {
            var result = await Mediator.Send(new IsEmailTaken.Query { Email = email});
            
            return result;
        }
        
        [AllowAnonymous]
        [HttpPost(nameof(RegisterUser))]
        public async Task<ActionResult<UserDto>> RegisterUser(RegisterUserDto registerUserDto, UserType userType)
        {
            if (await IsEmailTaken(registerUserDto.Email))
                return BadRequest("Email taken");
            

            var result = await Mediator.Send(new CreateUser.Command
            {
                RegisterUserDto = registerUserDto,
                UserType = userType
            });

            if (!result)
                return BadRequest("Problem registering user");
            

            var userDto = await Mediator.Send(new FindUserByEmail.Query {Email = registerUserDto.Email});

            if (userDto is null)
                return BadRequest("Problem registering user");

            return Ok(userDto);
        }

        [HttpGet(nameof(GetRooms))]
        public async Task<ActionResult<List<ChatRoomDto>>> GetRooms()
        {
            return await Mediator.Send(new GetRooms.Query());
        }
    }
}