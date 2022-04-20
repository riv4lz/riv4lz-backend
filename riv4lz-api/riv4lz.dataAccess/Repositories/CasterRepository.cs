using AutoMapper;
using Microsoft.EntityFrameworkCore;
using riv4lz.core.Models;
using riv4lz.dataAccess.Entities;
using riv4lz.domain.IRepositories;

namespace riv4lz.dataAccess.Repositories;

public class CasterRepository : ICasterRepository
{
    private readonly CasterDbContext _dbContext;
    private readonly IMapper _mapper;

    public CasterRepository(CasterDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext ?? throw new InvalidDataException(
            "CasterRepository must have a CasterDbContext");
        _mapper = mapper;
    }


    public List<CasterProfile> FindAll()
    {
        throw new NotImplementedException();
    }

    public CasterProfile Find(int id)
    {
        return null;
    }

    public bool Create(CasterProfile newCasterProfile)
    {
        _dbContext.CasterProfiles.Add(
            _mapper.Map(newCasterProfile, new CasterProfileEntity()));
        var result = _dbContext.SaveChanges();

        return result > 0;
    }

    public CasterProfile Update(int id, CasterProfile casterProfile)
    {
        throw new NotImplementedException();
    }

    public CasterProfile Delete(int id)
    {
        throw new NotImplementedException();
    }
    
    
    
    
}