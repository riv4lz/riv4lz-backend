using riv4lz.core.Models;

namespace riv4lz.core.IServices;

public interface ICasterService
{
    List<Caster> GetCasters();
    Caster Create();
}