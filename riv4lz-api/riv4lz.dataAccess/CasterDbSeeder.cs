using riv4lz.core.IServices;
using riv4lz.dataAccess.Entities;

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
        _ctx.Database.EnsureDeleted();
        if (_ctx.Database.EnsureCreated())
        {
            var caster1 = new CasterEntity()
            {
                Email = "t",
                GamerTag = "t",
                Password = "t"
            };

            _ctx.Casters.Add(caster1);
            _ctx.SaveChanges();
        }
    }
}