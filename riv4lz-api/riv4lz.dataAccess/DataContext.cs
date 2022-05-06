using Microsoft.EntityFrameworkCore;
using riv4lz.core.Entities;


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
            .HasOne<OrganisationProfile>(e => e.OrganisationProfile)
            .WithMany(o => o.Events)
            .HasForeignKey(o => o.OrganisationId);
        
        

        
        modelBuilder.Entity<Offer>()
            .HasOne<CasterProfile>(o => o.Caster)
            .WithMany(c => c.Offers)
            .HasForeignKey(o => o.CasterId); 
        
        


        modelBuilder.Entity<Order>()
            .HasOne(o => o.Event)
            .WithOne(e => e.Order)
            .HasForeignKey<Order>(e => e.EventId);

        modelBuilder.Entity<Order>()
            .HasOne(o => o.CasterProfile)
            .WithMany(c => c.Orders)
            .HasForeignKey(cp => cp.CasterId);

        modelBuilder.Entity<Order>()
            .HasOne(o => o.OrganisationProfile)
            .WithMany(c => c.Orders)
            .HasForeignKey(cp => cp.OrganisationId);
        
        modelBuilder.Entity<Team>()
            .HasIndex(t => t.Name).IsUnique();
        
        modelBuilder.Entity<CasterProfile>()
            .HasIndex(t => t.GamerTag).IsUnique();
        
        modelBuilder.Entity<OrganisationProfile>()
            .HasIndex(t => t.OrganisationName).IsUnique();
        /*
        modelBuilder.Entity<Offer>()
            .HasOne<Event>(o => o.Event)
            .WithMany(e => e.Offers)
            .HasForeignKey(o => o.EventId);
            
        
        modelBuilder.Entity<CasterProfile>()
            .HasMany<Offer>(c => c.Offers)
            .WithOne(o => o.Caster)
            .HasForeignKey(o => o.CasterId);
        */
    }

    public virtual DbSet<CasterProfile> CasterProfiles { get; set; }
    public virtual DbSet<OrganisationProfile> OrganisationProfiles { get; set; }
    public virtual DbSet<Event> Events { get; set; }
    public virtual DbSet<Offer> Offers { get; set; }
    
    public virtual DbSet<Order> Orders { get; set; }
    public virtual DbSet<Team> Teams { get; set; }
}