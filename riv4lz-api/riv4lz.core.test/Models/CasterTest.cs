using System;
using Xunit;

namespace riv4lz.core.test.Models;

public class CasterTest
{
    private CasterProfile _casterProfile;

    public CasterTest()
    {
        _casterProfile = new CasterProfile();
    }
    [Fact]
    public void Caster_CanBeInitialized()
    {
        Assert.NotNull(_casterProfile);
    }

  
   
}