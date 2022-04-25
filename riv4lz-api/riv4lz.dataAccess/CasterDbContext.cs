using Microsoft.EntityFrameworkCore;
using riv4lz.dataAccess.Entities;
using riv4lz.domain;


namespace riv4lz.dataAccess;

public class CasterDbContext : DbContext
{
    public CasterDbContext(DbContextOptions<CasterDbContext> options): base(options)
    {
        
    }

    public virtual DbSet<CasterProfileEntity> CasterProfiles { get; set; }
    public DbSet<OrganisationProfileEntity> OrganisationProfiles { get; set; }
    public DbSet<EventEntity> Events { get; set; }
    public DbSet<Comment> Comments { get; set; }
    
}