using Microsoft.EntityFrameworkCore;
using riv4lz.dataAccess.Entities;

namespace riv4lz.dataAccess;

public class CasterDbContext : DbContext
{
    public CasterDbContext(DbContextOptions<CasterDbContext> options): base(options)
    {
        
    }

    public virtual DbSet<CasterEntity> Casters { get; set; }
}