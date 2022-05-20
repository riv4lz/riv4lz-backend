using Microsoft.AspNetCore.Mvc;
using riv4lz.core.Enums;
using riv4lz.Mediator.Dtos.Profile;

namespace riv4lz.casterApi.Interfaces;

public interface IProfileController
{
    Task<ActionResult<List<ProfileDto>>> GetProfiles(UserType userType);
    Task<ActionResult<ProfileDto>> GetProfile(Guid id);
    Task<ActionResult<ProfileDto>> RegisterProfile(RegisterProfileDto registerProfileDto);
    Task<ActionResult> UpdateProfile(UpdateProfileDto updateProfileDto);
    ActionResult<ProfileDto> DeleteProfile(Guid id);
}