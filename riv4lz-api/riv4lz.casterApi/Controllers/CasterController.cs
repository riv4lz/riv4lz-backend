using Microsoft.AspNetCore.Mvc;
using riv4lz.casterApi.Interfaces;
using riv4lz.core.Enums;
using riv4lz.Mediator.Commands.ProfileCommands;
using riv4lz.Mediator.Dtos.Casters;
using riv4lz.Mediator.Queries.CasterQueries;


namespace riv4lz.casterApi.Controllers
{
    public class CasterController : BaseController, ICasterController
    {
        [HttpGet(nameof(GetCasterProfiles))]
        public async  Task<ActionResult<List<ProfileDto>>> GetCasterProfiles()
        {
            return await Mediator.Send(new GetProfiles.Query(){UserType = UserType.Caster});
        }

        [HttpGet(nameof(GetCasterProfile))]
        public async Task<ActionResult<ProfileDto>> GetCasterProfile(Guid id)
        {
            return await Mediator.Send(new GetProfile.Query {Id = id});
        }


        [HttpPost(nameof(RegisterCasterProfile))]
        public async Task<ActionResult<ProfileDto>> RegisterCasterProfile(RegisterProfileDto registerProfileDto)
        {
            var createResult = await Mediator.Send(new CreateProfile.Command
            {
                RegisterProfileDto = registerProfileDto
            });

            if (!createResult)
            {
                return BadRequest("Error storing profile information");
            }

            var profile = await Mediator.Send(
                new GetProfile.Query {Id = registerProfileDto.Id});

            return profile is not null ? profile : BadRequest("Problem loading profile");
        }



        [HttpPut(nameof(UpdateCasterProfile))]
        public async  Task<ActionResult> UpdateCasterProfile([FromBody] UpdateProfileDto updateProfileDto)
        {
            var result = await Mediator.Send(new UpdateProfile.Command
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
