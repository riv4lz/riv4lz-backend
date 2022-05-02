using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using riv4lz.Mediator.Commands.CasterCommands;
using riv4lz.Mediator.Dtos.Casters;
using riv4lz.Mediator.Queries.CasterQueries;


namespace riv4lz.casterApi.Controllers
{
    // TODO remove when auth v2 is ready
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class CasterController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CasterController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpGet(nameof(GetAll))]
        public async  Task<ActionResult<List<CasterProfileDto>>> GetAll()
        {
            return await _mediator.Send(new GetCasterProfiles.Query());
        }

        [HttpGet(nameof(GetCasterProfile))]
        public async Task<ActionResult<CasterProfileDto>> GetCasterProfile(Guid id)
        {
            return await _mediator.Send(new GetCasterProfile.Query {CasterId = id});
        }


        [HttpPost(nameof(RegisterCasterProfile))]
        public async Task<ActionResult<CasterProfileDto>> RegisterCasterProfile(RegisterCasterProfileDto registerCasterProfileDto)
        {
            var createResult = await _mediator.Send(new CreateCasterProfile.Command
            {
                RegisterCasterProfileDto = registerCasterProfileDto
            });

            if (!createResult)
            {
                return BadRequest("Error storing profile information");
            }

            var profile = await _mediator.Send(
                new GetCasterProfile.Query {CasterId = registerCasterProfileDto.CasterId});

            return profile != null ? profile : BadRequest("Problem loading profile");
        }



        [HttpPut(nameof(UpdateCasterProfile))]
        public async  Task<ActionResult> UpdateCasterProfile([FromBody] UpdateCasterProfileDto updateCasterProfileDto)
        {
            var result = await _mediator.Send(new UpdateCasterProfile.Command
            {
                UpdateCasterProfileDto = updateCasterProfileDto
            });

            return result ? Ok("Caster profile updated") : BadRequest("Error updating profile");
        }

        [HttpDelete(nameof(DeleteCaster))]
        public ActionResult<CasterProfileDto> DeleteCaster([FromBody] int id)
        {
            throw new NotImplementedException();
        }
    }
}
