using Microsoft.AspNetCore.Http;

namespace riv4lz.Mediator.Dtos;

public class UploadImageDto
{
    public Guid UserId { get; set; }
    public IFormFile File { get; set; }
}