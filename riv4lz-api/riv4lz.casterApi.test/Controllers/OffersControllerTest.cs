using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using riv4lz.casterApi.Controllers;
using riv4lz.casterApi.test.Helpers;
using riv4lz.Mediator.Dtos.Events;
using Xunit;

namespace riv4lz.casterApi.test.Controllers;

public class OffersControllerTest
{
    private readonly OffersController _controller;
    private readonly ControllerInfoHelper<OffersController> _infoHelper;

    public OffersControllerTest()
    {
        _controller = new OffersController();
        _infoHelper = new ControllerInfoHelper<OffersController>(_controller);
    }
    
    [Fact]
    public void OffersController_CanBeInitialized()
    {
        Assert.NotNull(_controller);
    }
    
    [Fact]
    public void OffersController_IsOfTypeControllerBase()
    {
        Assert.IsAssignableFrom<ControllerBase>(_controller);
    }
    
    [Fact]
    public void OffersController_IsOfTypeBaseController()
    {
        Assert.IsAssignableFrom<BaseController>(_controller);
    }
    
    [Fact]
    public void OffersController_UsesApiControllerAttribute()
    {
        var attr = _infoHelper.GetControllerAttributeByName("ApiControllerAttribute");
        
        Assert.NotNull(attr);
    }
    
    [Fact]
    public void OffersController_UsesRouteAttribute()
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

    #region GetOffer()

    [Fact]
    public void EventController_HasGetOfferMethod()
    {
        var method = _infoHelper.GetMethodByName("GetOffer");
        
        Assert.NotNull(method);
    }
    
    [Fact]
    public void EventController_GetOfferMethod_IsPublic()
    {
        var method = _infoHelper.GetMethodByName("GetOffer");
        
        Assert.True(method.IsPublic);
    }

    [Fact]
    public void EventController_GetOfferMethod_ReturnsTaskIfActionResult_OfferDto()
    {
        var method = _infoHelper.GetMethodByName("GetOffer");
        
        Assert.Equal(typeof(Task<ActionResult<OfferDto>>).FullName, method.ReturnType.FullName);
    }
    
    [Fact]
    public void EventController_GetOfferMethod_HasHttpGetAttribute()
    {
        var method = _infoHelper.GetMethodByName("GetOffer");

        Assert.NotNull(method.GetCustomAttribute<HttpGetAttribute>());
    }
    
    [Fact]
    public void EventController_GetOfferMethod_DoesNotAllowAnonymous()
    {
        var method = _infoHelper.GetMethodByName("GetOffer");
        
        Assert.False(method.GetCustomAttribute<AllowAnonymousAttribute>() != null);
    }
    
    [Fact]
    public void EventController_GetOfferMethod_TakesGuidAsParameter()
    {
        var method = _infoHelper.GetMethodByName("GetOffer");
        
        Assert.Equal(typeof(Guid).FullName, method.GetParameters()[0].ParameterType.FullName);
    }

    #endregion

    #region GetOffers()

    [Fact]
    public void EventController_HasGetOffersMethod()
    {
        var method = _infoHelper.GetMethodByName("GetOffers");
        
        Assert.NotNull(method);
    }
    
    [Fact]
    public void EventController_GetOffersMethod_IsPublic()
    {
        var method = _infoHelper.GetMethodByName("GetOffers");
        
        Assert.True(method.IsPublic);
    }

    [Fact]
    public void EventController_GetOffersMethod_ReturnsTaskOfActionResult_ListOfEventDto()
    {
        var method = _infoHelper.GetMethodByName("GetOffers");
        
        Assert.Equal(typeof(Task<ActionResult<List<OfferDto>>>).FullName, method.ReturnType.FullName);
    }
    
    [Fact]
    public void EventController_GetOffersMethod_HasHttpGetAttribute()
    {
        var method = _infoHelper.GetMethodByName("GetOffers");

        Assert.NotNull(method.GetCustomAttribute<HttpGetAttribute>());
    }
    
    [Fact]
    public void EventController_GetOffersMethod_DoesNotAllowAnonymous()
    {
        var method = _infoHelper.GetMethodByName("GetOffers");
        
        Assert.False(method.GetCustomAttribute<AllowAnonymousAttribute>() != null);
    }
    
    [Fact]
    public void EventController_GetOffersMethod_TakesGuidAsParameter()
    {
        var method = _infoHelper.GetMethodByName("GetOffers");
        
        Assert.Equal(typeof(Guid).FullName, method.GetParameters()[0].ParameterType.FullName);
    }

    #endregion

    #region CreateOffer()

    [Fact]
    public void EventController_HasCreateOfferMethod()
    {
        var method = _infoHelper.GetMethodByName("CreateOffer");
        
        Assert.NotNull(method);
    }
    
    [Fact]
    public void EventController_CreateOfferMethod_IsPublic()
    {
        var method = _infoHelper.GetMethodByName("CreateOffer");
        
        Assert.True(method.IsPublic);
    }

    [Fact]
    public void EventController_CreateOfferMethod_ReturnsTaskOfActionResult_Bool()
    {
        var method = _infoHelper.GetMethodByName("CreateOffer");
        
        Assert.Equal(typeof(Task<ActionResult<bool>>).FullName, method.ReturnType.FullName);
    }
    
    [Fact]
    public void EventController_CreateOfferMethod_HasHttpPostAttribute()
    {
        var method = _infoHelper.GetMethodByName("CreateOffer");

        Assert.NotNull(method.GetCustomAttribute<HttpPostAttribute>());
    }
    
    [Fact]
    public void EventController_CreateOfferMethod_DoesNotAllowAnonymous()
    {
        var method = _infoHelper.GetMethodByName("CreateOffer");
        
        Assert.False(method.GetCustomAttribute<AllowAnonymousAttribute>() != null);
    }
    
    [Fact]
    public void EventController_CreateOfferMethod_TakesCreateOfferDtoAsParameter()
    {
        var method = _infoHelper.GetMethodByName("CreateOffer");
        
        Assert.Equal(typeof(CreateOfferDto).FullName, method.GetParameters()[0].ParameterType.FullName);
    }

    #endregion
    
    #region UpdateOffer()

    [Fact]
    public void EventController_HasUpdateOfferMethod()
    {
        var method = _infoHelper.GetMethodByName("UpdateOffer");
        
        Assert.NotNull(method);
    }
    
    [Fact]
    public void EventController_UpdateOfferMethod_IsPublic()
    {
        var method = _infoHelper.GetMethodByName("UpdateOffer");
        
        Assert.True(method.IsPublic);
    }

    [Fact]
    public void EventController_UpdateOfferMethod_ReturnsTaskOfActionResult_Bool()
    {
        var method = _infoHelper.GetMethodByName("UpdateOffer");
        
        Assert.Equal(typeof(Task<ActionResult<bool>>).FullName, method.ReturnType.FullName);
    }
    
    [Fact]
    public void EventController_UpdateOfferMethod_HasHttpPutAttribute()
    {
        var method = _infoHelper.GetMethodByName("UpdateOffer");

        Assert.NotNull(method.GetCustomAttribute<HttpPutAttribute>());
    }
    
    [Fact]
    public void EventController_UpdateOfferMethod_DoesNotAllowAnonymous()
    {
        var method = _infoHelper.GetMethodByName("UpdateOffer");
        
        Assert.False(method.GetCustomAttribute<AllowAnonymousAttribute>() != null);
    }

    [Fact]
    public void EventController_UpdateOfferMethod_TakesUpdateOfferDtoAsFirstParameter()
    {
        var method = _infoHelper.GetMethodByName("UpdateOffer");
        
        Assert.Equal(typeof(UpdateOfferDto).FullName, method.GetParameters()[0].ParameterType.FullName);
    }
    
    #endregion

    #region AcceptOffer()

    [Fact]
    public void EventController_HasAcceptOfferMethod()
    {
        var method = _infoHelper.GetMethodByName("AcceptOffer");
        
        Assert.NotNull(method);
    }
    
    [Fact]
    public void EventController_AcceptOfferMethod_IsPublic()
    {
        var method = _infoHelper.GetMethodByName("AcceptOffer");
        
        Assert.True(method.IsPublic);
    }

    [Fact]
    public void EventController_AcceptOfferMethod_ReturnsTaskOfActionResult_Bool()
    {
        var method = _infoHelper.GetMethodByName("AcceptOffer");
        
        Assert.Equal(typeof(Task<ActionResult<bool>>).FullName, method.ReturnType.FullName);
    }
    
    [Fact]
    public void EventController_AcceptOfferMethod_HasHttpPutAttribute()
    {
        var method = _infoHelper.GetMethodByName("AcceptOffer");

        Assert.NotNull(method.GetCustomAttribute<HttpPutAttribute>());
    }
    
    [Fact]
    public void EventController_AcceptOfferMethod_DoesNotAllowAnonymous()
    {
        var method = _infoHelper.GetMethodByName("AcceptOffer");
        
        Assert.False(method.GetCustomAttribute<AllowAnonymousAttribute>() != null);
    }

    [Fact]
    public void EventController_AcceptOfferMethod_TakesUpdateOfferDtoAsFirstParameter()
    {
        var method = _infoHelper.GetMethodByName("AcceptOffer");
        
        Assert.Equal(typeof(UpdateOfferDto).FullName, method.GetParameters()[0].ParameterType.FullName);
    }

    #endregion

    #region RejectOffer()

    [Fact]
    public void EventController_HasRejectOfferMethod()
    {
        var method = _infoHelper.GetMethodByName("RejectOffer");
        
        Assert.NotNull(method);
    }
    
    [Fact]
    public void EventController_RejectOfferMethod_IsPublic()
    {
        var method = _infoHelper.GetMethodByName("RejectOffer");
        
        Assert.True(method.IsPublic);
    }

    [Fact]
    public void EventController_RejectOfferMethod_ReturnsTaskOfActionResult_Bool()
    {
        var method = _infoHelper.GetMethodByName("RejectOffer");
        
        Assert.Equal(typeof(Task<ActionResult<bool>>).FullName, method.ReturnType.FullName);
    }
    
    [Fact]
    public void EventController_RejectOfferMethod_HasHttpPutAttribute()
    {
        var method = _infoHelper.GetMethodByName("RejectOffer");

        Assert.NotNull(method.GetCustomAttribute<HttpPutAttribute>());
    }
    
    [Fact]
    public void EventController_RejectOfferMethod_DoesNotAllowAnonymous()
    {
        var method = _infoHelper.GetMethodByName("RejectOffer");
        
        Assert.False(method.GetCustomAttribute<AllowAnonymousAttribute>() != null);
    }

    [Fact]
    public void EventController_RejectOfferMethod_TakesUpdateOfferDtoAsFirstParameter()
    {
        var method = _infoHelper.GetMethodByName("RejectOffer");
        
        Assert.Equal(typeof(UpdateOfferDto).FullName, method.GetParameters()[0].ParameterType.FullName);
    }

    #endregion
    
    #region DeleteOffer()
    
    [Fact]
    public void EventController_HasDeleteOfferMethod()
    {
        var method = _infoHelper.GetMethodByName("DeleteOffer");
        
        Assert.NotNull(method);
    }
    
    [Fact]
    public void EventController_DeleteOfferMethod_IsPublic()
    {
        var method = _infoHelper.GetMethodByName("DeleteOffer");
        
        Assert.True(method.IsPublic);
    }

    [Fact]
    public void EventController_DeleteOfferMethod_ReturnsTaskOfActionResult_Bool()
    {
        var method = _infoHelper.GetMethodByName("DeleteOffer");
        
        Assert.Equal(typeof(Task<ActionResult<bool>>).FullName, method.ReturnType.FullName);
    }
    
    [Fact]
    public void EventController_DeleteOfferMethod_HasHttpDeleteAttribute()
    {
        var method = _infoHelper.GetMethodByName("DeleteOffer");

        Assert.NotNull(method.GetCustomAttribute<HttpDeleteAttribute>());
    }
    
    [Fact]
    public void EventController_DeleteOfferMethod_DoesNotAllowAnonymous()
    {
        var method = _infoHelper.GetMethodByName("DeleteOffer");
        
        Assert.False(method.GetCustomAttribute<AllowAnonymousAttribute>() != null);
    }

    [Fact]
    public void EventController_DeleteOfferMethod_TakesGuidAsFirstParameter()
    {
        var method = _infoHelper.GetMethodByName("DeleteOffer");
        
        Assert.Equal(typeof(Guid).FullName, method.GetParameters()[0].ParameterType.FullName);
    }

    #endregion
}