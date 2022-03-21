using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Moq;
using riv4lz.core.Models;
using riv4lz.domain.IRepositories;
using Xunit;

namespace riv4lz.domain.test.IRepositories;

public class ICasterRepositoryTest
{
    private readonly ICasterRepository _casterRepository;

    public ICasterRepositoryTest()
    {
        _casterRepository = new Mock<ICasterRepository>().Object;
    }
    [Fact]
    public void ICasterRepository_IsAvailable()
    {
        Assert.NotNull(_casterRepository);   
    }

    #region FindAll()

    [Fact]
    public void ICasterRepository_HasFindAllMethod()
    {
        var method = typeof(ICasterRepository).GetMethods()
            .FirstOrDefault(m => "FindAll".Equals(m.Name));
        
        Assert.NotNull(method);
    }

    [Fact]
    public void FindAllMethod_ReturnsListOfCaster()
    {
        var mock = new Mock<ICasterRepository>();
        var fakeList = new List<Caster>();
        mock.Setup(r => r.FindAll())
            .Returns(new List<Caster>());

        
        var repo = mock.Object;
        var casters = repo.FindAll();
        
        Assert.Equal(fakeList, casters);}

    #endregion

    #region Find()

    [Fact]
    public void ICasterRepository_HasFindMethod()
    {
        var method = typeof(ICasterRepository).GetMethods()
            .FirstOrDefault(m => "Find".Equals(m.Name));
        
        Assert.NotNull(method);
    }
    
    [Fact]
    public void FindMethod_ReturnsCaster()
    {
        var method = typeof(ICasterRepository).GetMethods()
            .FirstOrDefault(m => "Find".Equals(m.Name));
        
        Assert.Equal(typeof(Caster).FullName, method.ReturnType.FullName);
    }

    #endregion

    #region Create()

    [Fact]
    public void ICasterRepository_HasCreateMethod()
    {
        var method = typeof(ICasterRepository).GetMethods()
            .FirstOrDefault(m => "Create".Equals(m.Name));
        
        Assert.NotNull(method);
    }
    
    [Fact]
    public void CreateMethod_ReturnsCaster()
    {
        var method = typeof(ICasterRepository).GetMethods()
            .FirstOrDefault(m => "Find".Equals(m.Name));
        
        Assert.Equal(typeof(Caster).FullName, method.ReturnType.FullName);
    }

    #endregion

    #region Update()

    [Fact]
    public void ICasterRepository_HasUpdateMethod()
    {
        var method = typeof(ICasterRepository).GetMethods()
            .FirstOrDefault(m => "Update".Equals(m.Name));
        
        Assert.NotNull(method);
    }
    
    [Fact]
    public void UpdateMethod_ReturnsCaster()
    {
        var method = typeof(ICasterRepository).GetMethods()
            .FirstOrDefault(m => "Update".Equals(m.Name));
        
        Assert.Equal(typeof(Caster).FullName, method.ReturnType.FullName);
    }

    #endregion

    #region Delete()

    [Fact]
    public void ICasterRepository_HasDeleteMethod()
    {
        var method = typeof(ICasterRepository).GetMethods()
            .FirstOrDefault(m => "Delete".Equals(m.Name));
        
        Assert.NotNull(method);
    }
    
    [Fact]
    public void DeleteMethod_ReturnsCaster()
    {
        var method = typeof(ICasterRepository).GetMethods()
            .FirstOrDefault(m => "Delete".Equals(m.Name));
        
        Assert.Equal(typeof(Caster).FullName, method.ReturnType.FullName);
    }

    #endregion
}