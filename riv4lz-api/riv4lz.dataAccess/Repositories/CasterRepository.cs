using riv4lz.core.Models;
using riv4lz.domain.IRepositories;

namespace riv4lz.dataAccess.Repositories;

public class CasterRepository : ICasterRepository
{
    private readonly CasterDbContext _dbContext;

    public CasterRepository(CasterDbContext dbContext)
    {
        _dbContext = dbContext ?? throw new InvalidDataException(
            "CasterRepository must have a CasterDbContext");
    }

    public List<Caster> FindAll()
    {
        return _dbContext.Casters.Select(ce => new Caster()
        {
            Id = ce.Id,
            Email = ce.Email,
            Password = ce.Password,
            GamerTag = ce.GamerTag
        }).ToList();
    }
}