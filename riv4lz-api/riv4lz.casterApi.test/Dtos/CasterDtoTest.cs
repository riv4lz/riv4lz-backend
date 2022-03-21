using Xunit;

namespace riv4lz.casterApi.test.Dtos;

public class CasterDtoTest
{
    [Fact]
    public void CreateCasterDto_CanBeInitialized()
    {
        var dto = new CasterDtoTest();
        
        Assert.NotNull(dto);
    }
}