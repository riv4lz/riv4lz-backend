using System;
using System.Runtime.CompilerServices;
using riv4lz.core.Models;
using Xunit;

namespace riv4lz.core.test.Models;

public class BaseUserTest
{
    private BaseUser _baseUser;
    public BaseUserTest()
    {
        _baseUser = new BaseUser();
    }
    
    [Fact]
    public void BaseUser_CanBeInitialized()
    {
        Assert.NotNull(_baseUser);
    }
    
    [Fact]
    public void BaseUser_SetIdStoresId()
    {
        _baseUser.Id = 1;
        
        Assert.Equal(1, _baseUser.Id);
    }

    [Fact]
    public void BaseUserId_MustBeInt()
    {
        Assert.True(_baseUser.Id is int);
    }

    [Fact]
    public void BaseUser_SetEmail_UpdatesEmail()
    {
        _baseUser.Email = "t@t.tt";

        Assert.Equal("t@t.tt", _baseUser.Email);
    }

    [Fact]
    public void BaseUserEmail_IsString()
    {
        _baseUser.Email = "test";
        Assert.IsType<string>(_baseUser.Email);
    }

    [Fact]
    public void BaseUser_SetPassword_UpdatesPassword()
    {
        _baseUser.Password = "password";
        Assert.Equal("password", _baseUser.Password);
    }

    [Fact]
    public void BaseUserPassword_IsString()
    {
        _baseUser.Password = "password";
        Assert.IsType<string>(_baseUser.Password);
    }
}