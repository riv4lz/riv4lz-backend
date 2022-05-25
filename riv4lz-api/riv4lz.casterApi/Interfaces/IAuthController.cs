using Microsoft.AspNetCore.Mvc;
using riv4lz.core.Enums;
using riv4lz.Mediator.Dtos.Auth;

namespace riv4lz.casterApi.Interfaces;

public interface IAuthController
{
    Task<ActionResult<UserDto>> RegisterUser(RegisterUserDto registerUserDto);
    Task<ActionResult<UserDto>> Login(LoginDto loginDto);
    Task<ActionResult> UpdatePassword(UpdatePasswordDto updatePasswordDto);
    Task<ActionResult> UpdateEmail(UpdateEmailDto updateEmailDto);
    Task<ActionResult> UpdateUsername(UpdateUsernameDto updateEmailDto);
    Task<ActionResult<UserDto>> GetCurrentUser();
    Task<bool> IsEmailTaken(string email);
    
}