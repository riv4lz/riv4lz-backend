using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Moq;
using riv4lz.core.IServices;
using riv4lz.core.Models;
using riv4lz.domain.Services;
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
    

    #region GetCasters()

    [Fact]
    public void ICasterService_HasGetCastersMethod()
    {
        var method = typeof(ICasterService).GetMethods()
            .FirstOrDefault(m => "GetCasters".Equals(m.Name));
        
        Assert.NotNull(method);
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

    #endregion

    #region Create()

    [Fact]
    public void ICasterService_HasCreateMethod()
    {
        var method = typeof(ICasterService).GetMethods()
            .FirstOrDefault(m => "Create".Equals(m.Name));
        
        Assert.NotNull(method);
    }
    
    [Fact]
    public void Create_ReturnsCaster()
    {
        var method = typeof(ICasterService).GetMethods()
            .FirstOrDefault(m => "Create".Equals(m.Name));
        
        Assert.Equal(typeof(Caster).FullName, method.ReturnType.FullName);
    }

    #endregion

}