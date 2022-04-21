using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Moq;
using riv4lz.casterApi.Controllers;
using riv4lz.casterApi.Dtos;
using riv4lz.casterApi.test.Helpers;
using riv4lz.core.IServices;
using Xunit;

namespace riv4lz.casterApi.test.Controllers;

public class CasterControllerTest
{
    private readonly CasterController _controller;
    private readonly TypeInfo _typeInfo;
    private readonly ControllerInfoHelper<CasterController> _controllerInfoHelper;
    private readonly Mock<ICasterService> _casterService;

    public CasterControllerTest()
    {
        _casterService = new Mock<ICasterService>();
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

    

    #region Register();

    [Fact]
    public void CasterController_HasRegisterMethod()
    {
        var method = _controllerInfoHelper.GetMethodByName("Register");
        Assert.NotNull(method);
    }

    [Fact]
    public void CasterController_RegisterMethod_IsPublic()
    {
        var method = _controllerInfoHelper.GetMethodByName("Register");
        Assert.True(method.IsPublic);
    }
    
    [Fact]
    public void CasterController_RegisterMethod_HasPostHttpAttribute()
    {
        var attr = _controllerInfoHelper
            .GetCustomAttributeDataFromMethod("Register", "HttpPostAttribute");
        
        Assert.NotNull(attr);
    }
    
    [Fact]
    public void CasterController_RegisterMethod_ReturnsLiftOfCastersInActionResult()
    {
        var method = _controllerInfoHelper.GetMethodByName("Register");
        
        Assert.Equal(typeof(ActionResult<CasterDto>).FullName, method.ReturnType.FullName);
    }
    
    /*[Fact]
    public void CasterController_RegisterMethod_CallsServicesGetCasters_Once()
    {
        var caster = new CasterProfile();
        var dto = new CreateCasterDto();
        _casterService.Setup(s => s.Register(caster)).Returns(caster);
        _controller.Register(dto);
        
        _casterService.Verify(s => s.Register(caster), Times.Once);
    }*/

    #endregion

    #region Login()

    [Fact]
    public void CasterController_HasLoginMethod()
    {
        var method = _controllerInfoHelper.GetMethodByName("Login");
        Assert.NotNull(method);
    }

    [Fact]
    public void CasterController_LoginMethod_IsPublic()
    {
        var method = _controllerInfoHelper.GetMethodByName("Login");
        Assert.True(method.IsPublic);
    }
    
    [Fact]
    public void CasterController_LoginMethod_HasPostHttpAttribute()
    {
        var attr = _controllerInfoHelper
            .GetCustomAttributeDataFromMethod("Login", "HttpPostAttribute");
        
        Assert.NotNull(attr);
    }

    [Fact]
    public void CasterController_LoginMethod_ReturnsLoginCasterDto()
    {
        var method = _controllerInfoHelper.GetMethodByName("Login");
        
        Assert.Equal(typeof(ActionResult<CasterDto>).FullName, method.ReturnType.FullName);
    }
    
    #endregion

    #region UpdateCaster()

    [Fact]
    public void CasterController_HasUpdateCasterMethod()
    {
        var method = _controllerInfoHelper.GetMethodByName("UpdateCaster");
        Assert.NotNull(method);
    }

    [Fact]
    public void CasterController_UpdateCaster_IsPublic()
    {
        var method = _controllerInfoHelper.GetMethodByName("UpdateCaster");
        Assert.True(method.IsPublic);
    }
    
    [Fact]
    public void CasterController_UpdateCaster_HasPutHttpAttribute()
    {
        var attr = _controllerInfoHelper
            .GetCustomAttributeDataFromMethod("UpdateCaster", "HttpPutAttribute");
        
        Assert.NotNull(attr);
    }

    [Fact]
    public void CasterController_UpdateCaster_ReturnsCasterDto()
    {
        var method = _controllerInfoHelper.GetMethodByName("UpdateCaster");
        
        Assert.Equal(typeof(ActionResult<CasterDto>).FullName, method.ReturnType.FullName);
    }

    #endregion

    #region DeleteCaster()

    [Fact]
    public void CasterController_HasDeleteCasterMethod()
    {
        var method = _controllerInfoHelper.GetMethodByName("DeleteCaster");
        Assert.NotNull(method);
    }

    [Fact]
    public void CasterController_DeleteCaster_IsPublic()
    {
        var method = _controllerInfoHelper.GetMethodByName("DeleteCaster");
        Assert.True(method.IsPublic);
    }
    
    [Fact]
    public void CasterController_DeleteCaster_HasPutHttpAttribute()
    {
        var attr = _controllerInfoHelper
            .GetCustomAttributeDataFromMethod("DeleteCaster", "HttpDeleteAttribute");
        
        Assert.NotNull(attr);
    }

    [Fact]
    public void CasterController_DeleteCaster_ReturnsCasterDto()
    {
        var method = _controllerInfoHelper.GetMethodByName("DeleteCaster");
        
        Assert.Equal(typeof(ActionResult<CasterDto>).FullName, method.ReturnType.FullName);
    }

    #endregion

}