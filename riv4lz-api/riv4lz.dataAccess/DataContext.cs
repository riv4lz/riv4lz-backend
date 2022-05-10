using Microsoft.EntityFrameworkCore;
using riv4lz.core.Entities;
using riv4lz.core.Models;


namespace riv4lz.dataAccess;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options): base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Event>()
            .HasMany<Offer>(e => e.Offers)
            .WithOne(o => o.Event)
            .HasForeignKey(o => o.EventId);
        
        modelBuilder.Entity<Event>()
            .HasOne<Profile>(e => e.OrganisationProfile)
            .WithMany(o => o.Events)
            .HasForeignKey(o => o.OrganisationId);
        
        modelBuilder.Entity<Offer>()
            .HasOne<Profile>(o => o.Caster)
            .WithMany(c => c.Offers)
            .HasForeignKey(o => o.CasterId);

        modelBuilder.Entity<Team>()
            .HasIndex(t => t.Name).IsUnique();
        
        modelBuilder.Entity<Profile>()
            .HasIndex(t => t.Name).IsUnique();
    }

    public virtual DbSet<Profile> Profiles { get; set; }
    public virtual DbSet<Event> Events { get; set; }
    public virtual DbSet<Offer> Offers { get; set; }
    
    public virtual DbSet<Team> Teams { get; set; }
    public virtual DbSet<Image> Images { get; set; }
}