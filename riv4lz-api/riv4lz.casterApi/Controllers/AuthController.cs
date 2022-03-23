using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using riv4lz.casterApi.Dtos;
using riv4lz.casterApi.Services;
using riv4lz.security.DataAccess;
using riv4lz.security.Models;

namespace riv4lz.casterApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser<Guid>> _userManager;
        private readonly SignInManager<IdentityUser<Guid>> _signInManager;
        private readonly TokenService _tokenService;

        public AuthController(UserManager<IdentityUser<Guid>> userManager, 
            SignInManager<IdentityUser<Guid>> signInManager,
            TokenService tokenService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
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
                    Email = user.Email,
                    Token = _tokenService.CreateToken(user),
                };
            }

            return Unauthorized();
        }

        [AllowAnonymous]
        [HttpPost(nameof(RegisterCaster))]
        public async Task<ActionResult<UserDto>> RegisterCaster([FromBody] RegisterCasterDto registerCasterDto)
        {
            if (await _userManager.Users.AnyAsync(c => c.Email.Equals(registerCasterDto.Email)))
            {
                return BadRequest("Email taken");
            }
            if (await _userManager.Users.AnyAsync(c => c.UserName.Equals(registerCasterDto.GamerTag)))
            {
                return BadRequest("GamerTag taken");
            }

            var caster = new AppUser()
            {
                Email = registerCasterDto.Email,
                UserName = registerCasterDto.GamerTag,
            };

            var result = await _userManager.CreateAsync(caster, registerCasterDto.Password);

            if (result.Succeeded)
            {
                return new UserDto()
                {
                    Email = caster.Email,
                    Token = _tokenService.CreateToken(caster)
                };
            }

            return BadRequest("Problem registering caster");
        }
    }
}