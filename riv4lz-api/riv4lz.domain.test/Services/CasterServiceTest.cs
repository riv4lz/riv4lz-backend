using System.Collections.Generic;
using System.IO;
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

    #region Create()

    public void Create_CallsCasterRepositoryCreate_ExactlyOnce()
    {
        _service.Create();
        
        _mock.Verify(r => r.Create(),Times.Once);
    }

    #endregion

}