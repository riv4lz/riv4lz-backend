using EntityFrameworkCore.Testing.Moq;
using Microsoft.EntityFrameworkCore;
using riv4lz.core.Entities;
using Xunit;

namespace riv4lz.dataAccess.test;

public class DataContextTest
{
    private DataContext _dataContext;

    public DataContextTest()
    {
        _dataContext = Create.MockedDbContextFor<DataContext>();
    }

    [Fact]
    public void DbContext_WithDbContextOptions_IsAvailable()
    {
        Assert.NotNull(_dataContext);
    }

    [Fact]
    public void DbContext_DbSets_MustHaveDbSetWithTypeProfile()
    {
        Assert.True(_dataContext.Profiles is DbSet<Profile>);
    }
    
    [Fact]
    public void DbContext_DbSets_MustHaveDbSetWithTypeImages()
    {
        Assert.True(_dataContext.Images is DbSet<Image>);
    }
    
    [Fact]
    public void DbContext_DbSets_MustHaveDbSetWithTypeTeam()
    {
        Assert.True(_dataContext.Teams is DbSet<Team>);
    }
    
    [Fact]
    public void DbContext_DbSets_MustHaveDbSetWithTypeOffer()
    {
        Assert.True(_dataContext.Offers is DbSet<Offer>);
    }
    
    [Fact]
    public void DbContext_DbSets_MustHaveDbSetWithTypeEvent()
    {
        Assert.True(_dataContext.Events is DbSet<Event>);
    }

    [Fact]
    public void CasterContext_IsAssignableFromDbContext()
    {
        Assert.IsAssignableFrom<DbContext>(_dataContext);
    }
}