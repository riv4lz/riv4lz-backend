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

    public CasterServiceTest()
    {
        _mock = new Mock<ICasterRepository>();
        _service = new CasterService(_mock.Object);
        
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

    
    
}