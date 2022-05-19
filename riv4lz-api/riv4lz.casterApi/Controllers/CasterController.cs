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
        private ICasterController _casterControllerImplementation;

        [HttpGet(nameof(GetCasterProfiles))]
        public async  Task<ActionResult<List<ProfileDto>>> GetCasterProfiles()
        {
            var profiles = await Mediator
                .Send(new GetProfiles.Query(){UserType = UserType.Caster});

            if (profiles is null)
                return BadRequest("Fail to load profiles from database");

            return Ok(profiles);
        }

        [HttpGet(nameof(GetCasterProfile))]
        public async Task<ActionResult<ProfileDto>> GetCasterProfile(Guid id)
        {
            var profile = await Mediator.Send(new GetProfile.Query {Id = id});

            if (profile is null)
                return BadRequest("Failed to load profile from database");
            
            return Ok(profile);
        }


        [HttpPost(nameof(RegisterCasterProfile))]
        public async Task<ActionResult<ProfileDto>> RegisterCasterProfile(RegisterProfileDto registerProfileDto)
        {
            var result = await Mediator.Send(new CreateProfile.Command
            {
                RegisterProfileDto = registerProfileDto
            });

            if (!result)
                return BadRequest("Error storing profile information");
            

            var profile = await Mediator.Send(
                new GetProfile.Query {Id = registerProfileDto.Id});

            if (profile is null)
                return BadRequest("Failed to load profile from database");

            return Ok(profile);
        }
        
        [HttpPut(nameof(UpdateCasterProfile))]
        public async  Task<ActionResult> UpdateCasterProfile([FromBody] UpdateProfileDto updateProfileDto)
        {
            var result = await Mediator.Send(new UpdateProfile.Command
            {
                UpdateProfileDto = updateProfileDto
            });
            
            if (!result)
                return BadRequest("Failed to update profile");

            return Ok(true);
        }

        [HttpDelete(nameof(DeleteCaster))]
        public ActionResult<ProfileDto> DeleteCaster(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
