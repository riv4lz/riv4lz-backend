using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using riv4lz.core.Models;

namespace riv4lz.security.DataAccess;

public class AuthContext : IdentityDbContext<IdentityUser<Guid>, IdentityRole<Guid>, Guid>
{
    public AuthContext(DbContextOptions options) : base(options)
    {
        
    }
    
    
}

