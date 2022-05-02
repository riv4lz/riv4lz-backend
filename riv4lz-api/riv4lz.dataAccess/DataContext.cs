using Microsoft.EntityFrameworkCore;
using riv4lz.dataAccess.Entities;


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
        
        modelBuilder.Entity<Message>()
            .HasOne<ChatRoom>(m => m.ChatRoom)
            .WithMany(c => c.Messages)
            .HasForeignKey(m => m.ChatRoomId);
        
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
    public DbSet<OrganisationProfile> OrganisationProfiles { get; set; }
    public DbSet<Event> Events { get; set; }
    public DbSet<Offer> Offers { get; set; }
    public DbSet<ChatRoom> ChatRooms { get; set; }
    public DbSet<Message> Messages { get; set; }
}