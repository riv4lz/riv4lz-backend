using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using EntityFrameworkCore.Testing.Moq;
using riv4lz.core.Models;
using riv4lz.dataAccess.Entities;
using riv4lz.dataAccess.Repositories;
using riv4lz.domain.IRepositories;
using Xunit;

namespace riv4lz.dataAccess.test;

public class CasterRepositoryTest
{
    private readonly CasterRepository _repo;
    private readonly CasterDbContext _dbContext;
    private readonly List<CasterEntity> _list;
    public CasterRepositoryTest()
    {
        _dbContext = Create.MockedDbContextFor<CasterDbContext>();
        _repo = new CasterRepository(_dbContext);

        _list = new List<CasterEntity>()
        {
            new CasterEntity()
            {
                Id = 1, 
                Email = "t@t.dk", 
                Password = "12345",
                GamerTag = "Gamer1"
            },
            new CasterEntity()
            {
                Id = 2, 
                Email = "t@t.com", 
                Password = "12345",
                GamerTag = "Gamer2"
            }
        };
    }

    [Fact]
    public void CasterRepository_IsICasterRepository()
    {
        Assert.IsAssignableFrom<ICasterRepository>(_repo);
    }

    [Fact]
    public void CasterRepository_WithNullDbContext_ShouldThrowInvalidDataException()
    {
        Assert.Throws<InvalidDataException>(() => new CasterRepository(null));
    }
    
    [Fact]
    public void CasterRepository_WithNullDbContext_ShouldThrowInvalidDataExceptionWithMessage()
    {
        var exception = Assert
            .Throws<InvalidDataException>(() => new CasterRepository(null));
        Assert.Equal("CasterRepository must have a CasterDbContext", exception.Message);
    }

    [Fact]
    public void FindAll_GetAllCasterEntitiesInDbContext_AsAListOfCasters()
    {
        _dbContext.Set<CasterEntity>().AddRange(_list);
        _dbContext.SaveChanges();
        var expectedList = _list.Select(ce => new Caster()
        {
            Id = ce.Id,
            Email = ce.Email,
            GamerTag = ce.GamerTag,
            Password = ce.Password
        }).ToList();

        var actualList = _repo.FindAll();
        
        Assert.Equal(expectedList, actualList, new Comparer());
    }
    
    public class Comparer: IEqualityComparer<Caster>
    {
        public bool Equals(Caster x, Caster y)
        {
            if (ReferenceEquals(x, y)) return true;
            if (ReferenceEquals(x, null)) return false;
            if (ReferenceEquals(y, null)) return false;
            if (x.GetType() != y.GetType()) return false;
            return x.GamerTag == y.GamerTag;
        }

        public int GetHashCode(Caster obj)
        {
            return (obj.GamerTag != null ? obj.GamerTag.GetHashCode() : 0);
        }
    }
}