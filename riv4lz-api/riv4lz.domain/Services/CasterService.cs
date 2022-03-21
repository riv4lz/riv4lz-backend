using riv4lz.core.IServices;
using riv4lz.core.Models;
using riv4lz.domain.IRepositories;

namespace riv4lz.domain.Services;

public class CasterService : ICasterService
{
    private readonly ICasterRepository _repo;

    public CasterService(ICasterRepository repo)
    {
        _repo = repo ?? throw new InvalidDataException(
            "CasterRepository can't be null");
    }

    public List<Caster> GetCasters()
    {
        return _repo.FindAll();
    }

    public Caster GetCaster(int id)
    {
        return _repo.Find(id);
    }

    public Caster Create(Caster newCaster)
    {
        return _repo.Create(newCaster);
    }

    public Caster Update(int id, Caster caster)
    {
        return _repo.Update(id, caster);
    }

    public Caster Delete(int id)
    {
        return _repo.Delete(id);
    }

    public Caster GetCasterByEmail(string email)
    {
        return _repo.FindByEmail(email);
    }
}