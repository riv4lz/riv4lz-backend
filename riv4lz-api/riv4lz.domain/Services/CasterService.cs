using riv4lz.core.IServices;
using riv4lz.core.Models;
using riv4lz.domain.Repositories;

namespace riv4lz.domain.Services;

public class CasterService : ICasterService
{
    private readonly ICasterRepository _repo;

    public CasterService(ICasterRepository repo)
    {
        if (repo == null)
        {
            throw new InvalidDataException("CasterRepository can't be null");
        }

        _repo = repo;
    }

    public List<Caster> GetCasters()
    {
        return _repo.FindAll();
    }
}