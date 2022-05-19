using riv4lz.dataAccess.Cloudinary;
using Xunit;

namespace riv4lz.dataAccess.test.Cloudinary;

public class CloudinarySettingsTest
{
    private CloudinarySettings _settings;

    public CloudinarySettingsTest()
    {
        _settings = new CloudinarySettings();
    }
    
    [Fact]
    public void CloudinarySettings_CanBeInitialized()
    {
        Assert.NotNull(_settings);
    }
    
    [Fact]
    public void CloudinarySettings_CloudName_IsString()
    {
        _settings.CloudName = "test";
        Assert.IsType<string>(_settings.CloudName);
    }
    
    [Fact]
    public void CloudinarySettings_CloudName_CanBeSet()
    {
        _settings.CloudName = "test";
        Assert.Equal("test", _settings.CloudName);
    }
    
    [Fact]
    public void CloudinarySettings_CloudName_IsNullByDefault()
    {
        Assert.Null(_settings.CloudName);
    }
    
    [Fact]
    public void CloudinarySettings_ApiKey_IsString()
    {
        _settings.ApiKey = "test";
        Assert.IsType<string>(_settings.ApiKey);
    }
    
    [Fact]
    public void CloudinarySettings_ApiKey_CanBeSet()
    {
        _settings.ApiKey = "test";
        Assert.Equal("test", _settings.ApiKey);
    }
    
    [Fact]
    public void CloudinarySettings_ApiKey_IsNullByDefault()
    {
        Assert.Null(_settings.ApiKey);
    }
    
    [Fact]
    public void CloudinarySettings_ApiSecret_IsString()
    {
        _settings.ApiSecret = "test";
        Assert.IsType<string>(_settings.ApiSecret);
    }
    
    [Fact]
    public void CloudinarySettings_ApiSecret_CanBeSet()
    {
        _settings.ApiSecret = "test";
        Assert.Equal("test", _settings.ApiSecret);
    }
    
    
}