using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using riv4lz.casterApi.Dtos;
using riv4lz.core.IServices;
using riv4lz.core.Models;


namespace riv4lz.casterApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CasterController : ControllerBase
    {
        private readonly ICasterService _casterService;

        public CasterController(ICasterService casterService)
        {
            if (casterService == null)
            {
                throw new InvalidDataException("Constructor must have a CasterService");
            }

            _casterService = casterService;
        }
        
        [HttpGet]
        public ActionResult<List<Caster>> GetAll()
        {
            var casters = _casterService.GetCasters();
            
            if (casters == null)
            {
                // TODO change exception type
                throw new InvalidDataException();
            }

            return casters;
        }

        [HttpPost(nameof(Register))]
        public ActionResult<CasterDto> Register([FromBody] CreateCasterDto createCasterDto)
        {
            var newCaster = new Caster()
            {
                Email = createCasterDto.Email,
                GamerTag = createCasterDto.GamerTag,
                Password = createCasterDto.Password
            };
            
            var caster = _casterService.Create(newCaster);

            return new CasterDto
            {
                Id = caster.Id,
                GamerTag = caster.GamerTag,
                Email = caster.Email
            };
        }

        [HttpPost(nameof(Login))]
        public ActionResult<CasterDto> Login([FromBody] LoginCasterDto loginCasterDto)
        {
            var caster = _casterService.GetCasterByEmail(loginCasterDto.Email);

            if (caster == null)
            {
                return BadRequest("User not found");
            }

            return new CasterDto()
            {
                Email = caster.Email,
                GamerTag = caster.GamerTag,
                Id = caster.Id
            };
        }

        [HttpPut(nameof(UpdateCaster))]
        public ActionResult<CasterDto> UpdateCaster([FromBody] UpdateCasterDto updateCasterDto)
        {
            throw new NotImplementedException();
        }

        [HttpDelete(nameof(DeleteCaster))]
        public ActionResult<CasterDto> DeleteCaster([FromBody] int id)
        {
            throw new NotImplementedException();
        }
    }
}
