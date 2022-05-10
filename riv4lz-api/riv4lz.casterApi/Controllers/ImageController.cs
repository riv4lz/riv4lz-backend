using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using riv4lz.Mediator.Commands.ProfileCommands;
using riv4lz.Mediator.Dtos;

namespace riv4lz.casterApi.Controllers;

public class ImageController: BaseController
{
    [AllowAnonymous]
    [HttpPost(nameof(UploadImage))]
    public async Task<ActionResult<bool>> UploadImage([FromForm] AddImage.Command command)
    {
        return await Mediator.Send(command);
    }
}