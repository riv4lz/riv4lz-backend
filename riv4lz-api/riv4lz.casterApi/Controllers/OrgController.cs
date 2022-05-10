using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using riv4lz.core.Models;
using riv4lz.Mediator.Commands.ProfileCommands;
using riv4lz.Mediator.Dtos.Casters;
using riv4lz.Mediator.Queries.CasterQueries;

namespace riv4lz.casterApi.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class OrgController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public OrgController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        
        // TODO GetOrganisations

        [HttpGet(nameof(GetOrganisationProfile))]
        public async Task<ActionResult<ProfileDto>> GetOrganisationProfile(Guid id)
        {
            // TODO validate id
            return await _mediator.Send(new GetProfile.Query
            {
                Id = id
            });
        }
        
        [HttpGet(nameof(GetOrganisationProfiles))]
        public async Task<ActionResult<List<ProfileDto>>> GetOrganisationProfiles()
        {
            // TODO validate id
            return await _mediator.Send(new GetProfiles.Query() {UserType = UserType.Organisation});
        }

        [HttpPost(nameof(RegisterOrganisationProfile))]
        public async Task<ActionResult<ProfileDto>> RegisterOrganisationProfile(RegisterProfileDto registerProfileDto)
        {
            var createResult = await _mediator.Send(new CreateProfile.Command
            {
                RegisterProfileDto = registerProfileDto
            });

            if (!createResult)
            {
                return BadRequest("Error storing profile information");
            }

            var profile = await _mediator.Send(new GetProfile.Query
            {
                Id = registerProfileDto.Id
            });

            return profile != null ? profile : BadRequest("Problem loading profile");
        }

        [HttpPut(nameof(UpdateOrganisationProfile))]
        public async Task<ActionResult> UpdateOrganisationProfile(UpdateProfileDto updateProfileDto)
        {
            var result = await _mediator.Send(new UpdateProfile.Command
            {
                UpdateProfileDto = updateProfileDto
            });

            return result ? Ok("Profile updated") : BadRequest("Error updating profile");
        }

    }
}