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
}