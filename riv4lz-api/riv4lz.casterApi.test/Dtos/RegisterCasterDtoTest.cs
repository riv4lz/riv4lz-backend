using riv4lz.casterApi.Dtos;
using Xunit;

namespace riv4lz.casterApi.test.Dtos;

public class CreateCasterDtoTest
{
    [Fact]
    public void RegisterCasterDto_CanBeInitialized()
    {
        var dto = new RegisterCasterDto();
        
        Assert.NotNull(dto);
    }
}