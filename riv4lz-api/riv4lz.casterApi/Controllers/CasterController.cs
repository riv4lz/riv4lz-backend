using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using riv4lz.casterApi.Dtos;
using riv4lz.core.Models;
using riv4lz.Mediator;
using riv4lz.Mediator.Commands.CasterCommands;
using riv4lz.Mediator.Dtos;
using riv4lz.Mediator.Queries;
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
        public ActionResult<CasterDto> DeleteCaster([FromBody] int id)
        {
            throw new NotImplementedException();
        }
    }
}
