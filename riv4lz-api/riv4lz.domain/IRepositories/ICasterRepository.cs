using riv4lz.core.Models;

namespace riv4lz.domain.IRepositories;

public interface ICasterRepository
{
    List<Caster> FindAll();
    Caster Find(int id);
    Caster Create(Caster newCaster);
    Caster Update(int id, Caster caster);
    Caster Delete(int id);
    Caster FindByEmail(string email);
}