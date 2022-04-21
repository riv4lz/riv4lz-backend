using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using riv4lz.casterApi.Dtos;
using riv4lz.core.IServices;
using riv4lz.core.Models;
using riv4lz.Mediator;
using riv4lz.Mediator.Dtos;


namespace riv4lz.casterApi.Controllers
{
    // TODO remove when auth v2 is ready
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class CasterController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public CasterController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        
        [HttpGet]
        public ActionResult<List<CasterProfile>> GetAll()
        {
            throw new NotImplementedException();
        }

        
        [HttpPost(nameof(RegisterCasterProfile))]
        public async Task<ActionResult<CasterProfileDto>> RegisterCasterProfile(RegisterCasterProfileDto registerCasterProfileDto)
        {
            var profile = await _mediator.Send(new CreateCasterProfile.Command
            {
                RegisterCasterProfileDto = registerCasterProfileDto
            });

            return profile != null ? profile : BadRequest("Error saving profile");
        }



        [HttpPut(nameof(UpdateCaster))]
        public ActionResult<CasterDto> UpdateCaster([FromBody] UpdateCasterProfileDto updateCasterProfileDto)
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
