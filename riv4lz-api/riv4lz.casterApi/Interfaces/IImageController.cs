using Microsoft.AspNetCore.Mvc;
using riv4lz.Mediator.Commands.ProfileCommands;

namespace riv4lz.casterApi.Interfaces;

public interface IImageController
{
    Task<ActionResult<bool>> UploadImage([FromForm] AddImage.Command command);
}