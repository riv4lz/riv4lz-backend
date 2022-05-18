using Microsoft.AspNetCore.Mvc;
using riv4lz.casterApi.Controllers;
using riv4lz.casterApi.test.Helpers;
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

    #region Register()

    

    #endregion

    #region Login()

    

    #endregion
}