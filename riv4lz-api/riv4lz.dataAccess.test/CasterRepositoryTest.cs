using EntityFrameworkCore.Testing.Moq;
using Microsoft.EntityFrameworkCore;
using riv4lz.core.Models;
using Xunit;

namespace riv4lz.dataAccess.test;

public class CasterRepositoryTest
{
    
    public CasterRepositoryTest()
    {
        
    }
    [Fact]
    public void DbContext_WithDbContextOptions_IsAvailable()
    {
        var mockedDbContext = Create.MockedDbContextFor<CasterDbContext>();
        Assert.NotNull(mockedDbContext);
    }

    [Fact]
    public void DbContext_DbSets_MustHaveDbSetWithTypeCaster()
    {
        var mockedDbContext = Create.MockedDbContextFor<CasterDbContext>();
        Assert.True(mockedDbContext.Casters is DbSet<Caster>);
    }
}