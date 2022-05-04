using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using riv4lz.core.Models;
using riv4lz.Mediator.Commands.Auth;
using riv4lz.Mediator.Dtos;
using riv4lz.Mediator.Dtos.Auth;
using riv4lz.Mediator.Queries.Auth;
using riv4lz.Mediator.Queries.Chat;
using riv4lz.Mediator.Queries.EventQueries;

namespace riv4lz.casterApi.Controllers
{
    [AllowAnonymous]
    public class AuthController : BaseController
    {
        [AllowAnonymous]
        [HttpPost(nameof(Login))]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            var user = await Mediator.Send(new AuthenticateUser.Query {LoginDto = loginDto});
            if (user == null)
            {
                return Unauthorized();
            }

            return user;
        }

        [HttpPost(nameof(UpdatePassword))]
        public async Task<ActionResult> UpdatePassword(UpdatePasswordDto updatePasswordDto)
        {
            var result = await Mediator
                .Send(new UpdatePassword.Command {UpdatePasswordDto = updatePasswordDto});
            
            return result ? Ok("Password updated") : BadRequest("Error updating password");
        }

        [HttpPost(nameof(UpdateEmail))]
        public async Task<ActionResult> UpdateEmail(UpdateEmailDto updateEmailDto)
        {
            var emailTaken = await Mediator.Send(new IsEmailTaken.Query {Email = updateEmailDto.Email});
            
            if (emailTaken)
            {
                return BadRequest("Email is already taken");
            }
            
            var result = await Mediator
                .Send(new UpdateEmail.Command {UpdateEmailDto = updateEmailDto});
            
            return result ? Ok("Email updated") : BadRequest("Error updating email");
        }
        
        [HttpPost(nameof(UpdateUsername))]
        public async Task<ActionResult> UpdateUsername(UpdateUsernameDto updateEmailDto)
        {
            var usernameTaken = await Mediator.Send(
                new IsUsernameTaken.Query {Username = updateEmailDto.Username});

            if (usernameTaken)
            {
                return BadRequest("Username is already taken");
            }
            
            var result = await Mediator
                .Send(new UpdateUsername.Command {UpdateUsernameDto = updateEmailDto});
            
            return result ? Ok("Username updated") : BadRequest("Error updating username");
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
            return await Mediator.Send(new FindUserByEmail.Query {Email = User.FindFirstValue(ClaimTypes.Email)});
        }

        [AllowAnonymous]
        [HttpGet(nameof(IsEmailTaken))]
        public async Task<bool> IsEmailTaken(string email)
        {
            return await Mediator.Send(new IsEmailTaken.Query { Email = email});
        }
        
        // TODO slet?
        private async Task<ActionResult<UserDto>> RegisterUser(RegisterUserDto registerUserDto, UserType userType)
        {
            if (await IsEmailTaken(registerUserDto.Email))
            {
                return BadRequest("Email taken");
            }

            var result = await Mediator.Send(new CreateUser.Command
            {
                RegisterUserDto = registerUserDto,
                UserType = userType
            });

            if (!result)
            {
                return BadRequest("Problem registering user");
            }

            var userDto = await Mediator.Send(new FindUserByEmail.Query {Email = registerUserDto.Email});

            return userDto != null ? userDto : BadRequest("Problem registering user");
        }
        
        [HttpGet(nameof(GetRoom))]
        public async Task<ActionResult<ChatRoomWithMessagesDto>> GetRoom(string roomId)
        {
            return await Mediator.Send(new GetRoom.Query {RoomId = roomId});
        }
    }
}