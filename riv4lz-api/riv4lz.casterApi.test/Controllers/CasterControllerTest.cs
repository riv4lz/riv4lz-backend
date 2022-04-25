using System.Reflection;
using riv4lz.casterApi.Controllers;
using riv4lz.casterApi.test.Helpers;
using Xunit;

namespace riv4lz.casterApi.test.Controllers;

public class CasterControllerTest
{
    private readonly CasterController _controller;
    private readonly TypeInfo _typeInfo;
    private readonly ControllerInfoHelper<CasterController> _controllerInfoHelper;

    public CasterControllerTest()
    {
        _controllerInfoHelper = new ControllerInfoHelper<CasterController>(_controller);
        _typeInfo = typeof(CasterController).GetTypeInfo();
    }


    [Fact]
    public void CasterController_UsesApiControllerAttribute()
    {
        var attr = _controllerInfoHelper.GetControllerAttributeByName("ApiControllerAttribute");
        
        Assert.NotNull(attr);
    }

    [Fact]
    public void CasterController_UsesRouteAttribute()
    {
        var attr = _controllerInfoHelper.GetControllerAttributeByName("RouteAttribute");
        
        Assert.NotNull(attr);
    }
    
    [Fact]
    public void CasterController_UsesRouteAttribute_WithParamApiControllerNameRoute()
    {
        var template = _controllerInfoHelper.GetControllerAttributeTemplate("RouteAttribute");
        
        Assert.Equal("api/[controller]", template);
    }

}