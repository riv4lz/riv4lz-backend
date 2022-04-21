using Microsoft.AspNetCore.Mvc;
using riv4lz.core.Models;
using riv4lz.Mediator;
using riv4lz.Mediator.Dtos;

namespace riv4lz.casterApi.Helpers;

public class RegisterUserHelper
{
    private async Task<ActionResult<UserDto>> RegisterUser(RegisterUserDto registerUserDto)
    {
        if (IsEmailTaken(registerUserDto.Email).Result)
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
}