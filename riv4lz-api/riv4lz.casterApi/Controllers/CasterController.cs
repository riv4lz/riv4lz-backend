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

        [HttpPost]
        public ActionResult<CasterDto> Create([FromBody] CreateCasterDto createCasterDto)
        {
            var newCaster = _casterService.Create(new Caster());

            return new CasterDto
            {
                
            };
        }
    }
}
