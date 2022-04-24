using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using riv4lz.Mediator.Commands.OrgCommands;
using riv4lz.Mediator.Dtos;
using riv4lz.Mediator.Queries.OrganisationQueries;

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

        [HttpGet(nameof(GetOrganisationProfile))]
        public async Task<ActionResult<OrganisationProfileDto>> GetOrganisationProfile(Guid id)
        {
            // TODO validate id
            return await _mediator.Send(new GetOrganisationProfile.Query
            {
                OrganisationId = id
            });
        }

        [HttpPost(nameof(RegisterOrganisationProfile))]
        public async Task<ActionResult<OrganisationProfileDto>> RegisterOrganisationProfile(RegisterOrganisationProfileDto registerOrganisationProfileDto)
        {
            var createResult = await _mediator.Send(new CreateOrganisationProfile.Command
            {
                RegisterOrganisationProfileDto = registerOrganisationProfileDto
            });

            if (!createResult)
            {
                return BadRequest("Error storing profile information");
            }

            var profile = await _mediator.Send(new GetOrganisationProfile.Query
            {
                OrganisationId = registerOrganisationProfileDto.OrganisationId
            });

            return profile != null ? profile : BadRequest("Problem loading profile");
        }

    }
}