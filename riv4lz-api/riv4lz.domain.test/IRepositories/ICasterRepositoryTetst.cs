using System.Linq;
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

    #region GetAll()

    [Fact]
    public void ICasterRepository_HasFindAllMethod()
    {
        var method = typeof(ICasterRepository).GetMethods()
            .FirstOrDefault(m => "FindAll".Equals(m.Name));
        
        Assert.NotNull(method);
    }

    #endregion
    
}