using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using riv4lz.security.DataAccess;
using Xunit;

namespace riv4lz.security.test.DataAccess;

public class AuthContextTest
{
    private readonly AuthContext _context;
    
    public AuthContextTest()
    {
        var optionsBuilder = new DbContextOptionsBuilder<AuthContext>();
        optionsBuilder.UseInMemoryDatabase("AuthContextTest");
        _context = new AuthContext(optionsBuilder.Options);
    }
    [Fact]
    public void AuthContext_WithDbContextOptions_IsAvailable()
    {
        Assert.NotNull(_context);
    }

    [Fact]
    public void AuthContext_IsAssignableFrom_IdentityUser_guid()
    {
        Assert.IsAssignableFrom<IdentityDbContext<IdentityUser<Guid>, IdentityRole<Guid>, Guid>>(_context);
    }
}