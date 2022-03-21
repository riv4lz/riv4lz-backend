using riv4lz.core.Models;
using riv4lz.dataAccess.Entities;
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

    public Caster Find(int id)
    {
        var casterEntity = _dbContext.Casters.FirstOrDefault(c => c.Id == id);

        return new Caster()
        {
            Id = casterEntity.Id,
            Email = casterEntity.Email,
            GamerTag = casterEntity.GamerTag,
            Password = casterEntity.Password
        };
    }


    public Caster Create(Caster newCaster)
    {
        var caster = _dbContext.Casters.Add(new CasterEntity()
        {
            GamerTag = newCaster.GamerTag,
            Email = newCaster.Email,
            Password = newCaster.Password
        }).Entity;
        
        _dbContext.SaveChanges();

        return new Caster()
        {
            Id = caster.Id,
            Email = caster.Email,
            GamerTag = caster.GamerTag,
            Password = caster.Password
        };
    }

    public Caster Update(int id, Caster caster)
    {
        throw new NotImplementedException();
    }

    public Caster Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Caster FindByEmail(string email)
    {
        var casterEntity = _dbContext.Casters.FirstOrDefault(c => c.Email.Equals(email));

        return new Caster()
        {
            Id = casterEntity.Id,
            Email = casterEntity.Email,
            GamerTag = casterEntity.GamerTag,
            Password = casterEntity.Password
        };
    }
}