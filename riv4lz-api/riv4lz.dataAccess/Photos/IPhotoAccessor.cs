using Microsoft.AspNetCore.Http;

namespace riv4lz.dataAccess.Photos;

public interface IPhotoAccessor
{
    Task<PhotoUploadResult> AddPhoto(IFormFile file);
    Task<string> DeletePhoto(string publicId);
}