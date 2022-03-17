using riv4lz.core.Models;
using Xunit;

namespace riv4lz.core.test.Models;

public class CasterTest
{
    private Caster _caster;

    public CasterTest()
    {
        _caster = new Caster();
    }
    [Fact]
    public void Caster_CanBeInitialized()
    {
        Assert.NotNull(_caster);
    }

    [Fact]
    public void Caster_SetId_UpdatesId()
    {
        _caster.Id = 1;
        Assert.Equal(1, _caster.Id);
    }

    [Fact]
    public void Caster_SetEmail_UpdatesEmail()
    {
        _caster.Email = "test";
        Assert.Equal("test", _caster.Email);
    }

    [Fact]
    public void Caster_SetPassword_UpdatesPassword()
    {
        _caster.Password = "test";
        Assert.Equal("test", _caster.Password);
    }

    [Fact]
    public void Caster_SetGamerTag_UpdatesGamerTag()
    {
        _caster.GamerTag = "test";
        Assert.Equal("test", _caster.GamerTag);
    }

    [Fact]
    public void Caster_GamerTag_IsString()
    {
        _caster.GamerTag = "test";
        Assert.IsType<string>(_caster.GamerTag);
    }

    [Fact]
    public void Caster_Is_BaseUser()
    {
        var caster = new Caster();
        Assert.True(caster is BaseUser);
    }
}