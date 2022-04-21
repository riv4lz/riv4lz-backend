using System;
using Microsoft.AspNetCore.Identity;
using riv4lz.dataAccess.Entities;
using Xunit;

namespace riv4lz.security.test.Models;

public class AppUserTest
{
    private AppUser _appUser;

    public AppUserTest()
    {
        _appUser = new AppUser();
    }

    [Fact]
    public void AppUser_CanBeInitialized()
    {
        Assert.NotNull(_appUser);
    }

    [Fact]
    public void AppUser_InheritsFromIdentityUser_Guid()
    {
        Assert.IsAssignableFrom<IdentityUser<Guid>>(_appUser);
    }

    [Fact]
    public void AppUser_Id_IsTypeGuid()
    {
        Assert.IsType<Guid>(_appUser.Id);
    }

    [Fact]
    public void AppUser_SetIt_UpdatesId()
    {
        var id = new Guid();
        _appUser.Id = id;
        
        Assert.Equal(id, _appUser.Id);
    }
    
    [Fact]
    public void AppUser_SetEmail_UpdatesEmail()
    {
        _appUser.Email = "test";
        Assert.Equal("test", _appUser.Email);
    }

    [Fact]
    public void AppUser_Email_IsString()
    {
        _appUser.Email = "test";
        Assert.IsType<string>(_appUser.Email);
    }
    
    [Fact]
    public void AppUser_SetPasswordHash_UpdatesPasswordHash()
    {
        _appUser.PasswordHash = "test";
        Assert.Equal("test", _appUser.PasswordHash);
    }
    
}