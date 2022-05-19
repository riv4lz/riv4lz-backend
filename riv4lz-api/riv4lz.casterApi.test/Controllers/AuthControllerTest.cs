using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using riv4lz.casterApi.Controllers;
using riv4lz.casterApi.test.Helpers;
using riv4lz.core.Enums;
using riv4lz.Mediator.Dtos.Auth;
using Xunit;

namespace riv4lz.casterApi.test.Controllers;

public class AuthControllerTest
{
    private readonly AuthController _controller;
    private readonly ControllerInfoHelper<AuthController> _infoHelper;

    public AuthControllerTest()
    {
        _controller = new AuthController();
        _infoHelper = new ControllerInfoHelper<AuthController>(_controller);
    }
    [Fact]
    public void AuthController_IsOfTypeControllerBase()
    {
        Assert.IsAssignableFrom<ControllerBase>(_controller);
    }
    
    [Fact]
    public void AuthController_IsOfTypeBaseController()
    {
        Assert.IsAssignableFrom<BaseController>(_controller);
    }
    
    [Fact]
    public void AuthController_UsesApiControllerAttribute()
    {
        var attr = _infoHelper.GetControllerAttributeByName("ApiControllerAttribute");
        
        Assert.NotNull(attr);
    }
    
    [Fact]
    public void AuthController_UsesRouteAttribute()
    {
        var attr = _infoHelper.GetControllerAttributeByName("RouteAttribute");
        
        Assert.NotNull(attr);
    }
    
    [Fact]
    public void AuthController_UsesRouteAttribute_WithParamApiControllerNameRoute()
    {
        var template = _infoHelper.GetControllerAttributeTemplate("RouteAttribute");
        
        Assert.Equal("api/[controller]", template);
    }

    #region Login()

    [Fact]
    public void AuthController_HasLoginMethod()
    {
        var method = _infoHelper.GetMethodByName("Login");
        
        Assert.NotNull(method);
    }
    
    [Fact]
    public void AuthController_LoginMethod_IsPublic()
    {
        var method = _infoHelper.GetMethodByName("Login");
        
        Assert.True(method.IsPublic);
    }

    [Fact]
    public void AuthController_LoginMethod_ReturnsTaskIfActionResult_UserDto()
    {
        var method = _infoHelper.GetMethodByName("Login");
        
        Assert.Equal(typeof(Task<ActionResult<UserDto>>).FullName, method.ReturnType.FullName);
    }
    
    [Fact]
    public void AuthController_LoginMethod_HasHttpPostAttribute()
    {
        var method = _infoHelper.GetMethodByName("Login");

        Assert.NotNull(method.GetCustomAttribute<HttpPostAttribute>());
    }
    
    [Fact]
    public void AuthController_LoginMethod_HasAllowAnonymousAttribute()
    {
        var method = _infoHelper.GetMethodByName("Login");

        Assert.NotNull(method.GetCustomAttribute<AllowAnonymousAttribute>());
    }
    
    [Fact]
    public void AuthController_LoginMethod_TakesLoginDto()
    {
        var method = _infoHelper.GetMethodByName("Login");
        
        Assert.Equal(typeof(LoginDto).FullName, method.GetParameters()[0].ParameterType.FullName);
    }
    
    

    #endregion

    #region RegisterUser()

    [Fact]
    public void AuthController_HasRegisterUserMethod()
    {
        var method = _infoHelper.GetMethodByName("RegisterUser");
        
        Assert.NotNull(method);
    }
    
    [Fact]
    public void AuthController_RegisterUserMethod_IsPublic()
    {
        var method = _infoHelper.GetMethodByName("RegisterUser");
        
        Assert.True(method.IsPublic);
    }

    [Fact]
    public void AuthController_RegisterUserMethod_ReturnsTaskIfActionResult_UserDto()
    {
        var method = _infoHelper.GetMethodByName("RegisterUser");
        
        Assert.Equal(typeof(Task<ActionResult<UserDto>>).FullName, method.ReturnType.FullName);
    }
    
    [Fact]
    public void AuthController_RegisterUserMethod_HasHttpPostAttribute()
    {
        var method = _infoHelper.GetMethodByName("RegisterUser");

        Assert.NotNull(method.GetCustomAttribute<HttpPostAttribute>());
    }
    
    [Fact]
    public void AuthController_RegisterUserMethod_HasAllowAnonymousAttribute()
    {
        var method = _infoHelper.GetMethodByName("RegisterUser");

        Assert.NotNull(method.GetCustomAttribute<AllowAnonymousAttribute>());
    }
    
    [Fact]
    public void AuthController_RegisterUserMethod_TakesRegisterUserDto_AsFirstParameter()
    {
        var method = _infoHelper.GetMethodByName("RegisterUser");
        
        Assert.Equal(typeof(RegisterUserDto).FullName, method.GetParameters()[0].ParameterType.FullName);
    }
    
    [Fact]
    public void AuthController_RegisterUserMethod_TakesUserType_AsSecondParameter()
    {
        var method = _infoHelper.GetMethodByName("RegisterUser");
        
        Assert.Equal(typeof(UserType).FullName, method.GetParameters()[1].ParameterType.FullName);
    }
    

    #endregion
    
    #region UpdatePassword()
    
    [Fact]
    public void AuthController_HasUpdatePasswordMethod()
    {
        var method = _infoHelper.GetMethodByName("UpdatePassword");
        
        Assert.NotNull(method);
    }
    
    [Fact]
    public void AuthController_UpdatePasswordMethod_IsPublic()
    {
        var method = _infoHelper.GetMethodByName("UpdatePassword");
        
        Assert.True(method.IsPublic);
    }

    [Fact]
    public void AuthController_UpdatePasswordMethod_ReturnsTaskOfActionResult()
    {
        var method = _infoHelper.GetMethodByName("UpdatePassword");
        
        Assert.Equal(typeof(Task<ActionResult>).FullName, method.ReturnType.FullName);
    }
    
    [Fact]
    public void AuthController_UpdatePasswordMethod_HasHttpPostAttribute()
    {
        var method = _infoHelper.GetMethodByName("UpdatePassword");

        Assert.NotNull(method.GetCustomAttribute<HttpPutAttribute>());
    }
    
    [Fact]
    public void AuthController_UpdatePasswordMethod_TakesUpdatePasswordDto()
    {
        var method = _infoHelper.GetMethodByName("UpdatePassword");
        
        Assert.Equal(typeof(UpdatePasswordDto).FullName, method.GetParameters()[0].ParameterType.FullName);
    }
    
    
    #endregion
    
    #region UpdateUsername()
    
    [Fact]
    public void AuthController_HasUpdateUsernameMethod()
    {
        var method = _infoHelper.GetMethodByName("UpdateUsername");
        
        Assert.NotNull(method);
    }
    
    [Fact]
    public void AuthController_UpdateUsernameMethod_IsPublic()
    {
        var method = _infoHelper.GetMethodByName("UpdateUsername");
        
        Assert.True(method.IsPublic);
    }

    [Fact]
    public void AuthController_UpdateUsernameMethod_ReturnsTaskOfActionResult()
    {
        var method = _infoHelper.GetMethodByName("UpdateUsername");
        
        Assert.Equal(typeof(Task<ActionResult>).FullName, method.ReturnType.FullName);
    }
    
    [Fact]
    public void AuthController_UpdateUsernameMethod_HasHttpPostAttribute()
    {
        var method = _infoHelper.GetMethodByName("UpdateUsername");

        Assert.NotNull(method.GetCustomAttribute<HttpPutAttribute>());
    }
    
    [Fact]
    public void AuthController_UpdatePasswordMethod_TakesUpdateUsernameDto()
    {
        var method = _infoHelper.GetMethodByName("UpdateUsername");
        
        Assert.Equal(typeof(UpdateUsernameDto).FullName, method.GetParameters()[0].ParameterType.FullName);
    }
    
    #endregion
    
    #region UpdateEmail()
    
    [Fact]
    public void AuthController_HasUpdateEmailMethod()
    {
        var method = _infoHelper.GetMethodByName("UpdateEmail");
        
        Assert.NotNull(method);
    }
    
    [Fact]
    public void AuthController_UpdateEmailMethod_IsPublic()
    {
        var method = _infoHelper.GetMethodByName("UpdateEmail");
        
        Assert.True(method.IsPublic);
    }

    [Fact]
    public void AuthController_UpdateEmailMethod_ReturnsTaskOfActionResult()
    {
        var method = _infoHelper.GetMethodByName("UpdateEmail");
        
        Assert.Equal(typeof(Task<ActionResult>).FullName, method.ReturnType.FullName);
    }
    
    [Fact]
    public void AuthController_UpdateEmailMethod_HasHttpPostAttribute()
    {
        var method = _infoHelper.GetMethodByName("UpdateEmail");

        Assert.NotNull(method.GetCustomAttribute<HttpPutAttribute>());
    }
    
    [Fact]
    public void AuthController_UpdateEmailMethod_TakesUpdateUsernameDto()
    {
        var method = _infoHelper.GetMethodByName("UpdateEmail");
        
        Assert.Equal(typeof(UpdateEmailDto).FullName, method.GetParameters()[0].ParameterType.FullName);
    }
    
    #endregion
    
    #region IsEmailTaken()
    
    [Fact]
    public void AuthController_IsEmailTakenMethod_HasHttpGetAttribute()
    {
        var method = _infoHelper.GetMethodByName("IsEmailTaken");

        Assert.NotNull(method.GetCustomAttribute<HttpGetAttribute>());
    }
    
    [Fact]
    public void AuthController_IsEmailTakenMethod_ReturnsTaskOfBoolean()
    {
        var method = _infoHelper.GetMethodByName("IsEmailTaken");
        
        Assert.Equal(typeof(Task<bool>).FullName, method.ReturnType.FullName);
    }
    
    [Fact]
    public void AuthController_IsEmailTakenMethod_TakesString()
    {
        var method = _infoHelper.GetMethodByName("IsEmailTaken");
        
        Assert.Equal(typeof(string).FullName, method.GetParameters()[0].ParameterType.FullName);
    }
    
    [Fact]
    public void AuthController_IsEmailTakenMethod_IsPublic()
    {
        var method = _infoHelper.GetMethodByName("IsEmailTaken");
        
        Assert.True(method.IsPublic);
    }
    
    [Fact]
    public void AuthController_IsEmailTakenMethod_HasAllowAnonymousAttribute()
    {
        var method = _infoHelper.GetMethodByName("IsEmailTaken");
        
        Assert.NotNull(method.GetCustomAttribute<AllowAnonymousAttribute>());
    }

    #endregion
    
}