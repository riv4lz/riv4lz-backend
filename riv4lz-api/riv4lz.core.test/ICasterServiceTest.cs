using System.Collections.Generic;
using Moq;
using riv4lz.core.IServices;
using riv4lz.core.Models;
using Xunit;

namespace riv4lz.core.test;

public class ICasterServiceTest
{
    [Fact]
    public void ICasterService_IsAvailable()
    {
        var service = new Mock<ICasterService>().Object;
        Assert.NotNull(service);
    }
    
    

    [Fact]
    public void GetCasters_NoParams_ReturnsListsOfAllUsers()
    {
        var mock = new Mock<ICasterService>();
        var fakeList = new List<Caster>();
        mock.Setup(s => s.GetCasters())
            .Returns(new List<Caster>());

        
        var service = mock.Object;
        var casters = service.GetCasters();
        
        Assert.Equal(fakeList, casters);
    }
}