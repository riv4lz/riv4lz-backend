using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace riv4lz.security.DataAccess;

public class AuthContext : IdentityDbContext<IdentityUser<Guid>, IdentityRole<Guid>, Guid>
{
    public AuthContext(DbContextOptions<AuthContext> options) : base(options) {}
}

