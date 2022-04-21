using riv4lz.core.IServices;

namespace riv4lz.dataAccess;

public class CasterDbSeeder
{
    private readonly CasterDbContext _ctx;
    private readonly ICasterService _casterService;

    public CasterDbSeeder(CasterDbContext ctx)
    {
        _ctx = ctx;
    }

    public void SeedDevelopment()
    {
        _ctx.Database.EnsureCreated();

    }
}