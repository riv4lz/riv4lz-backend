using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using riv4lz.core.Models;
using riv4lz.Mediator.Commands.ProfileCommands;
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
        
        [HttpGet(nameof(GetCasterProfiles))]
        public async  Task<ActionResult<List<ProfileDto>>> GetCasterProfiles()
        {
            return await _mediator.Send(new GetProfiles.Query(){UserType = UserType.Caster});
        }

        [HttpGet(nameof(GetCasterProfile))]
        public async Task<ActionResult<ProfileDto>> GetCasterProfile(Guid id)
        {
            return await _mediator.Send(new GetProfile.Query {Id = id});
        }


        [HttpPost(nameof(RegisterCasterProfile))]
        public async Task<ActionResult<ProfileDto>> RegisterCasterProfile(RegisterProfileDto registerProfileDto)
        {
            var createResult = await _mediator.Send(new CreateProfile.Command
            {
                RegisterProfileDto = registerProfileDto
            });

            if (!createResult)
            {
                return BadRequest("Error storing profile information");
            }

            var profile = await _mediator.Send(
                new GetProfile.Query {Id = registerProfileDto.Id});

            return profile != null ? profile : BadRequest("Problem loading profile");
        }



        [HttpPut(nameof(UpdateCasterProfile))]
        public async  Task<ActionResult> UpdateCasterProfile([FromBody] UpdateProfileDto updateProfileDto)
        {
            var result = await _mediator.Send(new UpdateProfile.Command
            {
                UpdateProfileDto = updateProfileDto
            });

            return result ? Ok("Caster profile updated") : BadRequest("Error updating profile");
        }

        [HttpDelete(nameof(DeleteCaster))]
        public ActionResult<ProfileDto> DeleteCaster([FromBody] int id)
        {
            throw new NotImplementedException();
        }
    }
}
