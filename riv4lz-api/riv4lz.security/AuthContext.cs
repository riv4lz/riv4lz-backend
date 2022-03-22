using Microsoft.EntityFrameworkCore;

namespace riv4lz.security;

public class AuthContext : DbContext
{
    public AuthContext(DbContextOptions options) : base(options)
    {
        
    }

    public DbSet<AuthUserEntity> AuthUsers { get; set; }
}