using riv4lz.casterApi.Controllers;
using riv4lz.casterApi.Interfaces;
using Xunit;

namespace riv4lz.casterApi.test.Interfaces;

public class IAuthControllerTest
{
    private IAuthController _authController;

    public IAuthControllerTest()
    {
        _authController = new AuthController();
    }
    
    [Fact]
    public void IAuthController_CanBeInitialized()
    {
        Assert.NotNull(_authController);
    }
    
    [Fact]
    public void IAuthController_HasMethod_Login()
    {
        Assert.NotNull(_authController.Login);
    }
    
    [Fact]
    public void IAuthController_HasMethod_UpdatePassword()
    {
        Assert.NotNull(_authController.UpdatePassword);
    }
    
    [Fact]
    public void IAuthController_HasMethod_RegisterUser()
    {
        Assert.NotNull(_authController.RegisterUser);
    }
    
    [Fact]
    public void IAuthController_HasMethod_UpdateEmail()
    {
        Assert.NotNull(_authController.UpdateEmail);
    }
    
    [Fact]
    public void IAuthController_HasMethod_UpdateUsername()
    {
        Assert.NotNull(_authController.UpdateUsername);
    }
    
    [Fact]
    public void IAuthController_HasMethod_GetCurrentUser()
    {
        Assert.NotNull(_authController.GetCurrentUser);
    }
    
    [Fact]
    public void IAuthController_HasMethod_IsEmailTaken()
    {
        Assert.NotNull(_authController.IsEmailTaken);
    }
    
}