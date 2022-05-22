using Microsoft.AspNetCore.Mvc;
using riv4lz.Mediator.Dtos.Profile;

namespace riv4lz.casterApi.Interfaces;

public interface IImageController
{
    Task<ActionResult<bool>> UploadImageUrl(UploadImageUrlDto uploadImageUrlDto);
}