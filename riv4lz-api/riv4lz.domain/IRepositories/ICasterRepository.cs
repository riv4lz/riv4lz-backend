using riv4lz.core.Models;

namespace riv4lz.domain.IRepositories;

public interface ICasterRepository
{
    List<Caster> FindAll();
    Caster Create(Caster newCaster);
}