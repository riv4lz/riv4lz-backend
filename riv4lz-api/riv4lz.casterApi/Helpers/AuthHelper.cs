using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using riv4lz.casterApi.Dtos;

namespace riv4lz.casterApi.Helpers;

public class AuthHelper
{
    private readonly UserManager<IdentityUser<Guid>> _userManager;

    public AuthHelper(UserManager<IdentityUser<Guid>> userManager)
    {
        _userManager = userManager;
    }


/*
    public static Task<bool> ValidateCreateCasterDto(RegisterUserDto registerCasterDto)
    {
        if (await _userManager.Users.AnyAsync(c => c.Email.Equals(registerCasterDto.Email)))
        {
            return BadRequest("Email taken");
        }
        if (await _userManager.Users.AnyAsync(c => c.UserName.Equals(registerCasterDto.GamerTag)))
        {
            return BadRequest("GamerTag taken");
        }
        
    }
    */
}