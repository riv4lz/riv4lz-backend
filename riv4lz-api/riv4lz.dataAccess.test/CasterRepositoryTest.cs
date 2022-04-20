using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
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
    private readonly CasterEntity _casterEntity;
    private readonly IMapper _mapper;
    public CasterRepositoryTest()
    {
        _dbContext = Create.MockedDbContextFor<CasterDbContext>();
        _repo = new CasterRepository(_dbContext, _mapper);

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

        _casterEntity = new CasterEntity()
        {
            Id = 1,
            Email = "t@t.dk",
            Password = "12345",
            GamerTag = "Gamer1"
        };
    }

    [Fact]
    public void CasterRepository_IsICasterRepository()
    {
        Assert.IsAssignableFrom<ICasterRepository>(_repo);
    }

   

   

    #region Create()

    [Fact]
    public void CreateMethod_SavingCasterAsEntity_AssignsId()
    {
        var entity = new CasterEntity()
        {
            Email = "j@j.jj",
            GamerTag = "test",
            Password = "Pa$$w0rd"
        };
        var createdEntity = _dbContext.Set<CasterEntity>().Add(entity).Entity;
        _dbContext.SaveChanges();
        
        Assert.NotNull(createdEntity.Id);
    }

    #endregion

    #region Update()

        // TODO

    #endregion

    #region Delete()

        // TODO

    #endregion
    
    public class Comparer: IEqualityComparer<CasterProfile>
    {
        public bool Equals(CasterProfile x, CasterProfile y)
        {
            if (ReferenceEquals(x, y)) return true;
            if (ReferenceEquals(x, null)) return false;
            if (ReferenceEquals(y, null)) return false;
            if (x.GetType() != y.GetType()) return false;
            return x.CasterId.Equals(y.CasterId) && x.GamerTag == y.GamerTag && x.FirstName == y.FirstName 
                   && x.LastName == y.LastName && x.Description == y.Description && x.ProfileImage == y.ProfileImage 
                   && x.BannerImage == y.BannerImage && x.FacebookURL == y.FacebookURL && x.TwitterURL == y.TwitterURL 
                   && x.DiscordURL == y.DiscordURL && x.TwitchURL == y.TwitchURL;
        }

        public int GetHashCode(CasterProfile obj)
        {
            var hashCode = new HashCode();
            hashCode.Add(obj.CasterId);
            hashCode.Add(obj.GamerTag);
            hashCode.Add(obj.FirstName);
            hashCode.Add(obj.LastName);
            hashCode.Add(obj.Description);
            hashCode.Add(obj.ProfileImage);
            hashCode.Add(obj.BannerImage);
            hashCode.Add(obj.FacebookURL);
            hashCode.Add(obj.TwitterURL);
            hashCode.Add(obj.DiscordURL);
            hashCode.Add(obj.TwitchURL);
            return hashCode.ToHashCode();
        }
    }
}