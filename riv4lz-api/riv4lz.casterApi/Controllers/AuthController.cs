using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using riv4lz.casterApi.Dtos;
using riv4lz.casterApi.Services;
using riv4lz.core.Models;
using riv4lz.dataAccess.Entities;

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
            var roles = _userManager.GetRolesAsync(user);
            
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
        [HttpPost(nameof(Register))]
        public async Task<ActionResult<UserDto>> Register([FromBody] RegisterCasterDto registerCasterDto)
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
                Id = new Guid(),
                Email = registerCasterDto.Email,
                UserName = registerCasterDto.GamerTag,
            };

            var result = await _userManager.CreateAsync(caster, registerCasterDto.Password);

            if (result.Succeeded)
            {
                return CreateUserObject(caster);
            }

            return BadRequest("Problem registering caster");
        }

        [Authorize(Roles = "Caster")]
        [HttpPost(nameof(RegisterCaster))]
        public async Task<ActionResult<CasterDto>> RegisterCaster([FromBody] RegisterCasterDto registerCasterDto)
        {
            if (await _userManager.Users.AnyAsync(c => c.Email.Equals(registerCasterDto.Email)))
            {
                return BadRequest("Email taken");
            }
            if (await _userManager.Users.AnyAsync(c => c.UserName.Equals(registerCasterDto.GamerTag)))
            {
                return BadRequest("GamerTag taken");
            }

            var user = new CasterDto()
            {
                Email = "test"
            };
            return user;
        }

        [HttpGet(nameof(GetCurrentUser))]
        public async Task<ActionResult<UserDto>> GetCurrentUser()
        {
            var user = await _userManager.FindByEmailAsync(User.FindFirstValue(ClaimTypes.Email));

            return new UserDto()
            {
                Email = user.Email,
                Token = _tokenService.CreateToken(user)
            };
        }

        [Authorize(Roles = "Caster")]
        [HttpGet(nameof(GetString))]
        public ActionResult<string> GetString()
        {
            var user = new Caster();
            user.GamerTag = "hey";
            return "hey";
        }
        
        // TODO IsEmailTaken: bool
        // TODO IsUserNameTaken: bool (caster/ org)
        
        private UserDto CreateUserObject(AppUser appUser)
        {
            return new UserDto()
            {
                Email = appUser.Email,
                Token = _tokenService.CreateToken(appUser)
            };
        }
        
       
    }

    
}