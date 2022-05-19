using System.Collections.Generic;
using riv4lz.core.Entities;
using riv4lz.core.Enums;
using Xunit;

namespace riv4lz.core.test.Entities;

public class ImageTest
{
    private Image _image;

    public ImageTest()
    {
        _image = new Image();
    }

    [Fact]
    public void Image_CanBeInitialized()
    {
        Assert.NotNull(_image);
    }
    
    [Fact]
    public void Image_Id_IsString()
    {
        _image.Id = "test";
        Assert.IsType<string>(_image.Id);
    }
    
    [Fact]
    public void Image_Id_IsNullByDefault()
    {
        Assert.Null(_image.Id);
    }
    
    [Fact]
    public void Image_SettingId_SetsId()
    {
        _image.Id = "test";
        Assert.Equal("test", _image.Id);
    }
    
    [Fact]
    public void Image_Url_IsString()
    {
        _image.Url = "test";
        Assert.IsType<string>(_image.Url);
    }
    
    [Fact]
    public void Image_Url_IsNullByDefault()
    {
        Assert.Null(_image.Url);
    }
    
    [Fact]
    public void Image_SettingUrl_SetsUrl()
    {
        _image.Url = "test";
        Assert.Equal("test", _image.Url);
    }
    
    [Fact]
    public void Image_ImageType_IsImgType()
    {
        Assert.IsType<ImgType>(_image.ImageType);
    }
    
    [Fact]
    public void Image_ImageType_CanBeProfile()
    {
        _image.ImageType = ImgType.Profile;
        Assert.Equal(ImgType.Profile, _image.ImageType);
    }
    
    [Fact]
    public void Image_ImageType_CanBeBanner()
    {
        _image.ImageType = ImgType.Banner;
        Assert.Equal(ImgType.Banner, _image.ImageType);
    }

    [Fact]
    public void Image_Profiles_IsNullByDefault()
    {
        Assert.Null(_image.Profiles);
    }
    
    [Fact]
    public void Image_Profiles_CanAddProfile()
    {
        _image.Profiles = new List<Profile>();
        Assert.NotNull(_image.Profiles);
    }
}