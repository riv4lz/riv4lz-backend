using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Moq;
using riv4lz.casterApi.Controllers;
using riv4lz.casterApi.test.Helpers;
using riv4lz.core.IServices;
using riv4lz.core.Models;
using riv4lz.domain.Services;
using Xunit;

namespace riv4lz.casterApi.test.Controllers;

public class CasterControllerTest
{
    private readonly CasterController _controller;
    private readonly TypeInfo _typeInfo;
    private ControllerInfoHelper<CasterController> _controllerInfoHelper;
    private readonly Mock<ICasterService> _casterService;

    public CasterControllerTest()
    {
        _casterService = new Mock<ICasterService>();
        _controllerInfoHelper = new ControllerInfoHelper<CasterController>();
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

    [Fact]
    public void CasterController_HasGetAllMethod()
    {
        var method = _controllerInfoHelper.GetMethodByName("GetAll");
        
        Assert.NotNull(method);
    }

    [Fact]
    public void CasterController_HasGetAllMethod_IsPublic()
    {
        var method = _controllerInfoHelper.GetMethodByName("GetAll");
        
        Assert.True(method.IsPublic);
    }

    [Fact]
    public void CasterController_HasGetAllMethod_ReturnsLiftOfCastersInActionResult()
    {
        var method = _controllerInfoHelper.GetMethodByName("GetAll");
        
        Assert.Equal(typeof(ActionResult<List<Caster>>).FullName, method.ReturnType.FullName);
    }

    [Fact]
    public void CasterController_GetAllMethod_HasGetHttpAttribute()
    {
        var attr = _controllerInfoHelper
            .GetCustomAttributeDataFromMethod("GetAll", "HttpGetAttribute");
        
        Assert.NotNull(attr);
    }

    [Fact]
    public void CasterController_HasCasterService_IsOfTypeControllerBase()
    {
        var service = new Mock<ICasterService>();
        var controller = new CasterController(service.Object);
    }

}