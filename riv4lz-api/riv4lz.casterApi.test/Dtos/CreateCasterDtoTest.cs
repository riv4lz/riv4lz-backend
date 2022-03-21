using riv4lz.casterApi.Dtos;
using Xunit;

namespace riv4lz.casterApi.test.Dtos;

public class CreateCasterDtoTest
{
    [Fact]
    public void CreateCasterDto_CanBeInitialized()
    {
        var dto = new CreateCasterDto();
        
        Assert.NotNull(dto);
    }
}