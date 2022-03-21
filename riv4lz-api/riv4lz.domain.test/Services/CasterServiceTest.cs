using System.Collections.Generic;
using System.IO;
using System.Linq;
using Moq;
using riv4lz.core.IServices;
using riv4lz.core.Models;
using riv4lz.domain.IRepositories;
using riv4lz.domain.Services;
using Xunit;

namespace riv4lz.domain.test.Services;

public class CasterServiceTest
{
    private readonly Mock<ICasterRepository> _mock;
    private readonly CasterService _service;
    private readonly List<Caster> _expected;

    public CasterServiceTest()
    {
        _mock = new Mock<ICasterRepository>();
        _service = new CasterService(_mock.Object);
        _expected = new List<Caster>()
        {
            new Caster() {Id = 1, Email = "t@t.tt"},
            new Caster() {Id = 2, Email = "d@d.dd"}
        };
    }
    [Fact]
    public void CasterService_IsICasterService()
    {
        Assert.True(_service is ICasterService);
    }
    
    [Fact]
    public void CasterService_WithNullCasterRepository_ThrowsInvalidDataException()
    {
        Assert.Throws<InvalidDataException>(() => new CasterService(null));
    }
    
    [Fact]
    public void CasterService_WithNullCasterRepository_ThrowsInvalidDataExceptionWithMessage()
    {
        var exception = Assert.Throws<InvalidDataException>(() => new CasterService(null));
        
        Assert.Equal("CasterRepository can't be null", exception.Message);
    }

    #region GetCasters()
    
    [Fact]
    public void GetCasters_CallsCasterRepositoryFindAll_ExactlyOnce()
    {
        _service.GetCasters();
        
        _mock.Verify(r => r.FindAll(),Times.Once);
    }

    [Fact]
    public void GetCasters_NoFilter_ReturnsListOfAllCasters()
    {
        _mock.Setup(r => r.FindAll())
            .Returns(_expected);
        
        Assert.Equal(_expected, _service.GetCasters());
    }

    #endregion

    #region GetCaster()

    [Fact]
    public void GetCaster_CallsCasterRepositoryFindAll_ExactlyOnce()
    {
        _service.GetCaster(1);
        
        _mock.Verify(r => r.Find(1),Times.Once);
    }
    
    [Fact]
    public void GetCaster_NoFilter_ReturnsCaster()
    {
        var fakeCaster = new Caster();
        _mock.Setup(r => r.Find(1))
            .Returns(fakeCaster);
        
        Assert.Equal(fakeCaster, _service.GetCaster(1));
    }

    #endregion

    #region Create()

    [Fact]
    public void CreateMethod_CallsCasterRepositoryCreate_ExactlyOnce()
    {
        var caster = new Caster();
        _service.Create(caster);
        
        _mock.Verify(r => r.Create(caster),Times.Once);
    }

    [Fact]
    public void CreateMethod_ReturnsCaster()
    {
        var method = typeof(CasterService).GetMethods()
            .FirstOrDefault(m => "Create".Equals(m.Name));
        
        Assert.Equal(typeof(Caster).FullName, method.ReturnType.FullName);
    }

    #endregion

    #region Update()

    [Fact]
    public void UpdateMethod_CallsCasterRepositoryFindAll_ExactlyOnce()
    {
        var caster = new Caster();
        _service.Update(1, caster);
        
        _mock.Verify(r => r.Update(1, caster),Times.Once);
    }
    
    [Fact]
    public void UpdateMethod_ReturnsCaster()
    {
        var fakeCaster = new Caster();
        _mock.Setup(r => r.Update(1, fakeCaster))
            .Returns(fakeCaster);
        
        Assert.Equal(fakeCaster, _service.Update(1, fakeCaster));
    }

    #endregion

    #region Delete()

    [Fact]
    public void DeleteMethod_CallsCasterRepositoryFindAll_ExactlyOnce()
    {
        _service.Delete(1);
        
        _mock.Verify(r => r.Delete(1),Times.Once);
    }
    
    [Fact]
    public void DeleteMethod_ReturnsCaster()
    {
        var fakeCaster = new Caster();
        _mock.Setup(r => r.Find(1))
            .Returns(fakeCaster);
        
        Assert.Equal(fakeCaster, _service.GetCaster(1));
    }

    #endregion
    
}