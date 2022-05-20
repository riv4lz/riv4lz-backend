using Microsoft.AspNetCore.Http;
using riv4lz.core.Enums;

namespace riv4lz.Mediator.Dtos.Profile;

public class UploadImageUrlDto
{
    public Guid UserId { get; set; }
    public string ImageUrl { get; set; }
    public ImgType ImageType { get; set; }
}