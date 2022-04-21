using Moq;
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

    
}