
namespace riv4lz.dataAccess;

public class CasterDbSeeder
{
    private readonly CasterDbContext _ctx;

    public CasterDbSeeder(CasterDbContext ctx)
    {
        _ctx = ctx;
    }

    public void SeedDevelopment()
    {
        _ctx.Database.EnsureCreated();

    }
}