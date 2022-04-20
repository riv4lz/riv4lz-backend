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

    public List<CasterProfile> GetCasters()
    {
        return _repo.FindAll();
    }

    public CasterProfile GetCaster(int id)
    {
        return _repo.Find(id);
    }

    public bool Create(CasterProfile newCasterProfile)
    {
        return _repo.Create(newCasterProfile);
    }

    public CasterProfile Update(int id, CasterProfile casterProfile)
    {
        return _repo.Update(id, casterProfile);
    }

    public CasterProfile Delete(int id)
    {
        return _repo.Delete(id);
    }
}