using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Moq;
using riv4lz.core.IServices;
using riv4lz.core.Models;
using riv4lz.domain.Repositories;
using riv4lz.domain.Services;
using Xunit;

namespace riv4lz.domain.test.Services;

public class CasterServiceTest
{
    private Mock<ICasterRepository> _mock;

    public CasterServiceTest()
    {
        _mock = new Mock<ICasterRepository>();
    }
    [Fact]
    public void CasterService_IsICasterService()
    {
        var service = new CasterService(_mock.Object);
        Assert.True(service is ICasterService);
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

    [Fact]
    public void GetCasters_CallsCasterRepositoryFindAll_ExactlyOnce()
    {
        var service = new CasterService(_mock.Object);
        service.GetCasters();
        
        _mock.Verify(r => r.FindAll(),Times.Once);
    }

    [Fact]
    public void GetCasters_NoFilter_ReturnsListOfAllCasters()
    {
        var expected = new List<Caster>()
        {
            new Caster() {Id = 1, Email = "t@t.tt"},
            new Caster() {Id = 2, Email = "d@d.dd"}
        };
        _mock.Setup(r => r.FindAll())
            .Returns(expected);

        var service = new CasterService(_mock.Object);
        Assert.Equal(expected, service.GetCasters());
    }
}