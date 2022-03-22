using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace riv4lz.security;

public class AuthContext : IdentityDbContext<AppUser>
{
    public AuthContext(DbContextOptions options) : base(options)
    {
        
    }

    
}