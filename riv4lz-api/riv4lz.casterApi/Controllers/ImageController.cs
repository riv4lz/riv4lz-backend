using Microsoft.AspNetCore.Mvc;
using riv4lz.casterApi.Interfaces;
using riv4lz.Mediator.Commands.ProfileCommands;

namespace riv4lz.casterApi.Controllers;

public class ImageController: BaseController, IImageController
{
    [HttpPost(nameof(UploadImage))]
    public async Task<ActionResult<bool>> UploadImage([FromForm] AddImage.Command command)
    {
        var result = await Mediator.Send(command);
        
        if(!result)
            return BadRequest("Failed to upload image");

        return true;
    }
}