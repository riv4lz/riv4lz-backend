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
    

    #region GetCasters()

    [Fact]
    public void ICasterService_HasGetCastersMethod()
    {
        var method = typeof(ICasterService).GetMethods()
            .FirstOrDefault(m => "GetCasters".Equals(m.Name));
        
        Assert.NotNull(method);
    }
    
    [Fact]
    public void GetCastersMethod_NoParams_ReturnsListsOfAllUsers()
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

    #region GetCaster()

    [Fact]
    public void ICasterService_HasGetCasterMethod()
    {
        var method = typeof(ICasterService).GetMethods()
            .FirstOrDefault(m => "GetCaster".Equals(m.Name));
        
        Assert.NotNull(method);
    }
    
    [Fact]
    public void GetCasterMethod_ReturnsCaster()
    {
        var method = typeof(ICasterService).GetMethods()
            .FirstOrDefault(m => "GetCaster".Equals(m.Name));
        
        Assert.Equal(typeof(Caster).FullName, method.ReturnType.FullName);
    }

    #endregion

    #region GetCasterByEmail()
    
    [Fact]
    public void ICasterService_HasGetCasterByEmailMethod()
    {
        var method = typeof(ICasterService).GetMethods()
            .FirstOrDefault(m => "GetCasterByEmail".Equals(m.Name));
        
        Assert.NotNull(method);
    }
    
    [Fact]
    public void GetCasterMethod_ReturnsGetCasterByEmail()
    {
        var method = typeof(ICasterService).GetMethods()
            .FirstOrDefault(m => "GetCasterByEmail".Equals(m.Name));
        
        Assert.Equal(typeof(Caster).FullName, method.ReturnType.FullName);
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
    public void CreateMethod_ReturnsCaster()
    {
        var method = typeof(ICasterService).GetMethods()
            .FirstOrDefault(m => "Create".Equals(m.Name));
        
        Assert.Equal(typeof(Caster).FullName, method.ReturnType.FullName);
    }

    #endregion

    #region Update()

    [Fact]
    public void ICasterService_HasUpdateMethod()
    {
        var method = typeof(ICasterService).GetMethods()
            .FirstOrDefault(m => "Update".Equals(m.Name));
        
        Assert.NotNull(method);
    }
    
    [Fact]
    public void UpdateMethod_ReturnsCaster()
    {
        var method = typeof(ICasterService).GetMethods()
            .FirstOrDefault(m => "Update".Equals(m.Name));
        
        Assert.Equal(typeof(Caster).FullName, method.ReturnType.FullName);
    }

    #endregion

    #region Delete()

    [Fact]
    public void ICasterService_HasDeleteMethod()
    {
        var method = typeof(ICasterService).GetMethods()
            .FirstOrDefault(m => "Delete".Equals(m.Name));
        
        Assert.NotNull(method);
    }
    
    [Fact]
    public void DeleteMethod_ReturnsCaster()
    {
        var method = typeof(ICasterService).GetMethods()
            .FirstOrDefault(m => "Delete".Equals(m.Name));
        
        Assert.Equal(typeof(Caster).FullName, method.ReturnType.FullName);
    }

    #endregion
}