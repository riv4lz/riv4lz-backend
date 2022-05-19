using Microsoft.AspNetCore.Mvc;
using riv4lz.casterApi.Controllers;
using riv4lz.casterApi.test.Helpers;
using Xunit;

namespace riv4lz.casterApi.test.Controllers;

public class BaseControllerTest
{
    private readonly BaseController _controller;
    private readonly ControllerInfoHelper<BaseController> _infoHelper;

    public BaseControllerTest()
    {
        _controller = new BaseController();
        _infoHelper = new ControllerInfoHelper<BaseController>(_controller);
    }
    
    [Fact]
    public void BaseController_IsOfTypeControllerBase()
    {
        Assert.IsAssignableFrom<ControllerBase>(_controller);
    }
    
    
    [Fact]
    public void BaseController_UsesApiControllerAttribute()
    {
        var attr = _infoHelper.GetControllerAttributeByName("ApiControllerAttribute");
        
        Assert.NotNull(attr);
    }
    
    [Fact]
    public void BaseController_UsesRouteAttribute()
    {
        var attr = _infoHelper.GetControllerAttributeByName("RouteAttribute");
        
        Assert.NotNull(attr);
    }
    
    [Fact]
    public void BaseController_UsesRouteAttribute_WithParamApiControllerNameRoute()
    {
        var template = _infoHelper.GetControllerAttributeTemplate("RouteAttribute");
        
        Assert.Equal("api/[controller]", template);
    }
}