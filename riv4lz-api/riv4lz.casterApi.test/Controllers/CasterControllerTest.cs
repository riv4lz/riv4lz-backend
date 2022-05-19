using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using riv4lz.casterApi.Controllers;
using riv4lz.casterApi.Interfaces;
using riv4lz.casterApi.test.Helpers;
using riv4lz.Mediator.Dtos.Casters;
using Xunit;

namespace riv4lz.casterApi.test.Controllers;

public class CasterControllerTest
{
    private readonly CasterController _controller;
    private readonly ControllerInfoHelper<CasterController> _controllerInfoHelper;

    public CasterControllerTest()
    {
        _controller = new CasterController();
        _controllerInfoHelper = new ControllerInfoHelper<CasterController>(_controller);
    }
    
    [Fact]
    public void CasterController_CanBeInitialized()
    {
        Assert.NotNull(_controller);
    }
    
    [Fact]
    public void CasterController_IsOfTypeControllerBase()
    {
        Assert.IsAssignableFrom<ControllerBase>(_controller);
    }
    
    [Fact]
    public void CasterController_IsOfTypeBaseController()
    {
        Assert.IsAssignableFrom<BaseController>(_controller);
    }
    
    [Fact]
    public void CasterController_IsOfTypeICasterController()
    {
        Assert.IsAssignableFrom<ICasterController>(_controller);
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

    #region GetCasterProfile()

    [Fact]
    public void CasterController_HasGetCasterProfileMethod()
    {
        var method = _controllerInfoHelper.GetMethodByName("GetCasterProfile");
        
        Assert.NotNull(method);
    }
    
    [Fact]
    public void CasterController_GetCasterProfileMethod_ReturnsTaskOfActionResultProfileDto()
    {
        var method = _controllerInfoHelper.GetMethodByName("GetCasterProfile");
        
        Assert.Equal(typeof(Task<ActionResult<ProfileDto>>), method.ReturnType);
    }
    
    [Fact]
    public void AuthController_GetCasterProfileMethod_IsPublic()
    {
        var method = _controllerInfoHelper.GetMethodByName("GetCasterProfile");
        
        Assert.True(method.IsPublic);
    }

    #endregion

}