using riv4lz.core.Models;

namespace riv4lz.core.IServices;

public interface ICasterService
{
    List<CasterProfile> GetCasters();
    CasterProfile GetCaster(int id);
    bool Create(CasterProfile newCasterProfile);
    CasterProfile Update(int id, CasterProfile casterProfile);
    CasterProfile Delete(int id);
}