using Microsoft.AspNetCore.Mvc;
using riv4lz.casterApi.Interfaces;
using riv4lz.Mediator.Commands.Profile;
using riv4lz.Mediator.Dtos.Profile;

namespace riv4lz.casterApi.Controllers;

public class ImageController: BaseController, IImageController
{
    [HttpPost(nameof(UploadImageUrl))]
    public async Task<ActionResult<bool>> UploadImageUrl(UploadImageUrlDto uploadImageUrlDto)
    {
        var result = await Mediator.Send(new UploadImageUrl.Command
        {
            UploadImageUrlDto = uploadImageUrlDto
        });

        if (!result)
            return BadRequest("Error saving image url to database");

        return true;
    }
}