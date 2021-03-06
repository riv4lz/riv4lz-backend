using Microsoft.AspNetCore.Mvc;
using riv4lz.casterApi.Interfaces;
using riv4lz.core.Enums;
using riv4lz.Mediator.Commands.Profile;
using riv4lz.Mediator.Dtos.Profile;
using riv4lz.Mediator.Queries.Profile;


namespace riv4lz.casterApi.Controllers
{
    public class ProfileController : BaseController, IProfileController
    {
        [HttpGet(nameof(GetAllProfiles))]
        public async Task<ActionResult<List<ProfileDto>>> GetAllProfiles()
        {
            var profiles = await Mediator.Send(new GetAllProfiles.Query());

            if (profiles is null)
            {
                return BadRequest("Error loading profiles");
            }
            
            return Ok(profiles);
        }

        [HttpGet(nameof(GetProfiles))]
        public async  Task<ActionResult<List<ProfileDto>>> GetProfiles(UserType userType)
        {
            var profiles = await Mediator
                .Send(new GetProfiles.Query(){UserType = userType});

            if (profiles is null)
                return BadRequest("Fail to load profiles from database");

            return Ok(profiles);
        }

        [HttpGet(nameof(GetProfile))]
        public async Task<ActionResult<ProfileDto>> GetProfile(Guid id)
        {
            var profile = await Mediator.Send(new GetProfile.Query {Id = id});

            if (profile is null)
                return BadRequest("Failed to load profile from database");
            
            return Ok(profile);
        }


        [HttpPost(nameof(RegisterProfile))]
        public async Task<ActionResult<ProfileDto>> RegisterProfile(RegisterProfileDto registerProfileDto)
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
        
        [HttpPut(nameof(UpdateProfile))]
        public async  Task<ActionResult> UpdateProfile(UpdateProfileDto updateProfileDto)
        {
            var result = await Mediator.Send(new UpdateProfile.Command
            {
                UpdateProfileDto = updateProfileDto
            });
            
            if (!result)
                return BadRequest("Failed to update profile");

            return Ok(true);
        }

        [HttpDelete(nameof(DeleteProfile))]
        public async Task<ActionResult<bool>> DeleteProfile(Guid id)
        {
            return false;
        }
    }
}
