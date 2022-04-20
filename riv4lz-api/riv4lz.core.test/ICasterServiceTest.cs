using System.Collections.Generic;
using System.Linq;
using Moq;
using riv4lz.core.IServices;
using riv4lz.core.Models;
using Xunit;

namespace riv4lz.core.test;

public class ICasterServiceTest
{
    private readonly ICasterService _casterService;
    public ICasterServiceTest()
    {
        _casterService = new Mock<ICasterService>().Object;
    }
    
    [Fact]
    public void ICasterService_IsAvailable()
    {
        Assert.NotNull(_casterService);
    }
    

   
}