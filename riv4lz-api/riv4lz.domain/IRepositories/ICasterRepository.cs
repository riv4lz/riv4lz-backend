using riv4lz.core.Models;

namespace riv4lz.domain.IRepositories;

public interface ICasterRepository
{
    List<CasterProfile> FindAll();
    CasterProfile Find(int id);
    bool Create(CasterProfile newCasterProfile);
    CasterProfile Update(int id, CasterProfile casterProfile);
    CasterProfile Delete(int id);
    
}