using riv4lz.core.Models;
using Xunit;

namespace riv4lz.core.test.Models;

public class BaseUserTest
{
    [Fact]
    public void BaseUser_CanBeInitialized()
    {
        var baseUser = new BaseUser();
        Assert.NotNull(baseUser);
    }
}