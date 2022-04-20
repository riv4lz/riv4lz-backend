using EntityFrameworkCore.Testing.Moq;
using Microsoft.EntityFrameworkCore;
using riv4lz.dataAccess.Entities;
using Xunit;

namespace riv4lz.dataAccess.test;

public class CasterDbContextTest
{
    [Fact]
    public void DbContext_WithDbContextOptions_IsAvailable()
    {
        var mockedDbContext = Create.MockedDbContextFor<CasterDbContext>();
        Assert.NotNull(mockedDbContext);
    }

    [Fact]
    public void DbContext_DbSets_MustHaveDbSetWithTypeCasterEntity()
    {
        var mockedDbContext = Create.MockedDbContextFor<CasterDbContext>();
        Assert.True(mockedDbContext.CasterProfiles is DbSet<CasterProfileEntity>);
    }

    [Fact]
    public void CasterContext_IsAssignableFromDbContext()
    {
        var mockedDbContext = Create.MockedDbContextFor<CasterDbContext>();
        Assert.IsAssignableFrom<DbContext>(mockedDbContext);
    }
}