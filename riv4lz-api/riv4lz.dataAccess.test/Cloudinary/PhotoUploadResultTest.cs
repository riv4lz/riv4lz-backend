using riv4lz.dataAccess.Cloudinary;
using Xunit;

namespace riv4lz.dataAccess.test.Cloudinary;

public class PhotoUploadResultTest
{
    private PhotoUploadResult _photoUploadResult;

    public PhotoUploadResultTest()
    {
        _photoUploadResult = new PhotoUploadResult();
    }
    
    [Fact]
    public void PhotoUploadResult_CanBeInitialized()
    {
        Assert.NotNull(_photoUploadResult);
    }
    
    [Fact]
    public void PhotoUploadResult_CanBeInitializedWithData()
    {
        var photoUploadResult = new PhotoUploadResult
        {
            PublicId = "publicId",
            Url = "url"
        };
        
        Assert.NotNull(photoUploadResult);
        Assert.Equal("publicId", photoUploadResult.PublicId);
        Assert.Equal("url", photoUploadResult.Url);
    }
    
    [Fact]
    public void PhotoUploadResult_CanBeInitializedWithDataAndNulls()
    {
        var photoUploadResult = new PhotoUploadResult
        {
            PublicId = null,
            Url = null
        };
        
        Assert.NotNull(photoUploadResult);
        Assert.Null(photoUploadResult.PublicId);
        Assert.Null(photoUploadResult.Url);
    }
    
    [Fact]
    public void PhotoUploadResult_CanBeInitializedWithDataAndEmptyStrings()
    {
        var photoUploadResult = new PhotoUploadResult
        {
            PublicId = "",
            Url = ""
        };
        
        Assert.NotNull(photoUploadResult);
        Assert.Equal("", photoUploadResult.PublicId);
        Assert.Equal("", photoUploadResult.Url);
    }
    
    [Fact]
    public void PhotoUploadResult_CanBeInitializedWithDataAndWhitespaceStrings()
    {
        var photoUploadResult = new PhotoUploadResult
        {
            PublicId = " ",
            Url = " "
        };
        
        Assert.NotNull(photoUploadResult);
        Assert.Equal(" ", photoUploadResult.PublicId);
        Assert.Equal(" ", photoUploadResult.Url);
    }
    
    [Fact]
    public void PhotoUploadResult_PublicId_IsString()
    {
        _photoUploadResult.PublicId = "publicId";
        Assert.IsType<string>(_photoUploadResult.PublicId);
    }
    
    [Fact]
    public void PhotoUploadResult_Url_IsString()
    {
        _photoUploadResult.Url = "url";
        Assert.IsType<string>(_photoUploadResult.Url);
    }
    
    [Fact]
    public void PhotoUploadResult_PublicId_IsNullByDefault()
    {
        Assert.Null(_photoUploadResult.PublicId);
    }
    
    [Fact]
    public void PhotoUploadResult_Url_IsNullByDefault()
    {
        Assert.Null(_photoUploadResult.Url);
    }
    
    [Fact]
    public void PhotoUploadResult_PublicId_CanBeSet()
    {
        _photoUploadResult.PublicId = "publicId";
        Assert.Equal("publicId", _photoUploadResult.PublicId);
    }
    
    [Fact]
    public void PhotoUploadResult_Url_CanBeSet()
    {
        _photoUploadResult.Url = "url";
        Assert.Equal("url", _photoUploadResult.Url);
    }
    
}