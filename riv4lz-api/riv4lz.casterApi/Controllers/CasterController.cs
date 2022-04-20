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
        private readonly ICasterService _casterService;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public CasterController(ICasterService casterService, IMediator mediator, IMapper mapper)
        {
            if (casterService == null)
            {
                throw new InvalidDataException("Constructor must have a CasterService");
            }

            _casterService = casterService;
            _mediator = mediator;
            _mapper = mapper;
        }
        
        [HttpGet]
        public ActionResult<List<CasterProfile>> GetAll()
        {
            //var casters = _casterService.GetCasters();

            var dto = new CreateCasterProfileDto()
            {
                CasterId = Guid.NewGuid(),
                FirstName = "asd",
                LastName = "asd",
                Description = "asd",
                GamerTag = "asd",
                BannerImage = "asd",
                ProfileImage = "asd",
                FacebookURL = "asd",
                DiscordURL = "asd",
                TwitchURL = "asd",
                TwitterURL = "asd"
            };

            var profile = new CasterProfile();
            _mapper.Map(dto, profile);

            var users = new List<CasterProfile>();
            users.Add(profile);

            return users;
        }

        
        [HttpPost(nameof(RegisterCasterProfile))]
        public async Task<bool> RegisterCasterProfile(CreateCasterProfileDto casterProfileDto)
        {
            return await _mediator.Send(new CreateCasterProfile.Command
            {
                CasterProfile = _mapper.Map(casterProfileDto, new CasterProfile())
            });
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
