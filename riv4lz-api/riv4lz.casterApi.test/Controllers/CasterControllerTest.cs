using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Internal;
using Moq;
using riv4lz.casterApi.Controllers;
using riv4lz.casterApi.Dtos;
using riv4lz.casterApi.test.Helpers;
using riv4lz.core.IServices;
using riv4lz.core.Models;
using riv4lz.dataAccess.Repositories;
using riv4lz.domain.Services;
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
        _controller = new CasterController(_casterService.Object);
        _controllerInfoHelper = new ControllerInfoHelper<CasterController>(_controller);
        _typeInfo = typeof(CasterController).GetTypeInfo();
    }

    [Fact]
    public void CasterController_IsOfTypeControllerBase()
    {
        Assert.IsAssignableFrom<ControllerBase>(_controller);
    }
    
    [Fact]
    public void CasterController_HasCasterService_IsOfTypeControllerBase()
    {
        var service = new Mock<ICasterService>();
        var controller = new CasterController(service.Object);

        Assert.IsAssignableFrom<ControllerBase>(controller);
    }

    [Fact]
    public void CasterController_WithNullProductService_ThrowsInvalidDataException()
    {
        Assert.Throws<InvalidDataException>(
            () => new CasterController(null));
    }
    
    [Fact]
    public void CasterController_WithNullProductService_ThrowsInvalidDataExceptionWithMessage()
    {
        var exception = Assert.Throws<InvalidDataException>(
            () => new CasterController(null));
        
        Assert.Equal("Constructor must have a CasterService", exception.Message);
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

    #region GetAll()

    
    [Fact]
    public void CasterController_HasGetAllMethod()
    {
        var method = _controllerInfoHelper.GetMethodByName("GetAll");
        
        Assert.NotNull(method);
    }

    [Fact]
    public void CasterController_GetAllMethod_IsPublic()
    {
        var method = _controllerInfoHelper.GetMethodByName("GetAll");
        
        Assert.True(method.IsPublic);
    }

    [Fact]
    public void CasterController_GetAllMethod_ReturnsLiftOfCastersInActionResult()
    {
        var method = _controllerInfoHelper.GetMethodByName("GetAll");
        
        Assert.Equal(typeof(ActionResult<List<Caster>>).FullName, method.ReturnType.FullName);
    }

    [Fact]
    public void CasterController_GetAllMethod_IfListIsNull_ThrowsInternalServerErrorException()
    {
        _casterService.Setup(s => s.GetCasters()).Returns((List<Caster>) null);
        
        // TODO make custom exception system
        Assert.Throws<InvalidDataException>(() => _controller.GetAll());
    }
    

    [Fact]
    public void CasterController_GetAllMethod_HasGetHttpAttribute()
    {
        var attr = _controllerInfoHelper
            .GetCustomAttributeDataFromMethod("GetAll", "HttpGetAttribute");
        
        Assert.NotNull(attr);
    }

    [Fact]
    public void CasterController_GetAllMethod_CallsServicesGetCasters_Once()
    {
        _casterService.Setup(s => s.GetCasters()).Returns((List<Caster>)null);
        _controller.GetAll();
        
        _casterService.Verify(s => s.GetCasters(), Times.Once);
    }

    #endregion

    #region Register();

    [Fact]
    public void CasterController_HasCreateMethod()
    {
        var method = _controllerInfoHelper.GetMethodByName("Create");
        Assert.NotNull(method);
    }

    [Fact]
    public void CasterController_CreateMethod_IsPublic()
    {
        var method = _controllerInfoHelper.GetMethodByName("Create");
        Assert.True(method.IsPublic);
    }
    
    [Fact]
    public void CasterController_CreateMethod_HasPostHttpAttribute()
    {
        var attr = _controllerInfoHelper
            .GetCustomAttributeDataFromMethod("Create", "HttpPostAttribute");
        
        Assert.NotNull(attr);
    }
    
    [Fact]
    public void CasterController_CreateMethod_ReturnsLiftOfCastersInActionResult()
    {
        var method = _controllerInfoHelper.GetMethodByName("Create");
        
        Assert.Equal(typeof(ActionResult<CasterDto>).FullName, method.ReturnType.FullName);
    }
    
    [Fact]
    public void CasterController_CreateMethod_CallsServicesGetCasters_Once()
    {
        var caster = new Caster();
        var dto = new CreateCasterDto();
        //_casterService.Setup(s => s.Create(caster)).Returns(caster);
        _controller.Create(dto);
        
        _casterService.Verify(s => s.Create(caster), Times.Once);
    }

    #endregion
    

}