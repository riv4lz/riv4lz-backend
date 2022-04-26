using riv4lz.Mediator.Dtos;
using riv4lz.Mediator.Dtos.Auth;
using Xunit;

namespace riv4lz.casterApi.test.Dtos;

public class CreateCasterDtoTest
{
    [Fact]
    public void RegisterCasterDto_CanBeInitialized()
    {
        var dto = new RegisterUserDto();
        
        Assert.NotNull(dto);
    }
}