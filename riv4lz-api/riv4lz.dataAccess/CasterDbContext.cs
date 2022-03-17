using Microsoft.EntityFrameworkCore;
using riv4lz.core.Models;

namespace riv4lz.dataAccess;

public class CasterDbContext : DbContext
{
    public CasterDbContext(DbContextOptions<CasterDbContext> options): base(options)
    {
        
    }

    public virtual DbSet<Caster> Casters { get; set; }
}