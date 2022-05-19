using Microsoft.AspNetCore.Mvc;
using riv4lz.Mediator.Dtos.Casters;

namespace riv4lz.casterApi.Interfaces;

public interface ICasterController
{
    Task<ActionResult<List<ProfileDto>>> GetCasterProfiles();
    Task<ActionResult<ProfileDto>> GetCasterProfile(Guid id);
    Task<ActionResult<ProfileDto>> RegisterCasterProfile(RegisterProfileDto registerProfileDto);
    Task<ActionResult> UpdateCasterProfile([FromBody] UpdateProfileDto updateProfileDto);
    ActionResult<ProfileDto> DeleteCaster([FromBody] int id);
}