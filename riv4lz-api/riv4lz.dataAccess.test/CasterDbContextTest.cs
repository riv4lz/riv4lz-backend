using EntityFrameworkCore.Testing.Moq;
using Microsoft.EntityFrameworkCore;
using riv4lz.core.Entities;
using Xunit;

namespace riv4lz.dataAccess.test;

public class CasterDbContextTest
{
    [Fact]
    public void DbContext_WithDbContextOptions_IsAvailable()
    {
        var mockedDbContext = Create.MockedDbContextFor<DataContext>();
        Assert.NotNull(mockedDbContext);
    }

    [Fact]
    public void DbContext_DbSets_MustHaveDbSetWithTypeCasterEntity()
    {
        var mockedDbContext = Create.MockedDbContextFor<DataContext>();
        Assert.True(mockedDbContext.CasterProfiles is DbSet<CasterProfile>);
    }

    [Fact]
    public void CasterContext_IsAssignableFromDbContext()
    {
        var mockedDbContext = Create.MockedDbContextFor<DataContext>();
        Assert.IsAssignableFrom<DbContext>(mockedDbContext);
    }
}