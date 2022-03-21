using riv4lz.core.Models;

namespace riv4lz.core.IServices;

public interface ICasterService
{
    List<Caster> GetCasters();
    Caster GetCaster(int id);
    Caster Create(Caster newCaster);
    Caster Update(int id, Caster caster);
    Caster Delete(int id);
    Caster GetCasterByEmail(string email);
}