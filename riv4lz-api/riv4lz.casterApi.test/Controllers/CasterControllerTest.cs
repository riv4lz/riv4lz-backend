using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using riv4lz.casterApi.Controllers;
using Xunit;

namespace riv4lz.casterApi.test.Controllers;

public class CasterControllerTest
{
    private readonly CasterController _controller;
    private readonly TypeInfo _typeInfo;
    
    public CasterControllerTest()
    {
        _controller = new CasterController();
        _typeInfo = typeof(CasterController).GetTypeInfo();
    }

    [Fact]
    public void CasterController_IsOfTypeControllerBase()
    {
        Assert.IsAssignableFrom<ControllerBase>(_controller);
    }

    [Fact]
    public void CasterController_UsesApiControllerAttribute()
    {
        var attr = _typeInfo
            .GetCustomAttributes().FirstOrDefault(a => a.GetType().Name.Equals("ApiControllerAttribute"));
        
        Assert.NotNull(attr);
    }

    [Fact]
    public void CasterController_UsesRouteAttribute()
    {
        var attr = _typeInfo
            .GetCustomAttributes().FirstOrDefault(
                a => a.GetType().Name.Equals("RouteAttribute"));
        
        Assert.NotNull(attr);
    }
    
    [Fact]
    public void CasterController_UsesRouteAttribute_WithParamApiControllerNameRoute()
    {
        var attr = _typeInfo
            .GetCustomAttributes().FirstOrDefault(
                a => a.GetType().Name.Equals("RouteAttribute"));
        var routeAttribute = attr as RouteAttribute;
        
        Assert.Equal("api/[controller]", routeAttribute.Template);
    }
}