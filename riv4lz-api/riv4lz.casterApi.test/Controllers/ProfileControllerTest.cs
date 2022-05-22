using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using riv4lz.casterApi.Controllers;
using riv4lz.casterApi.Interfaces;
using riv4lz.casterApi.test.Helpers;
using riv4lz.core.Enums;
using riv4lz.Mediator.Dtos.Profile;
using Xunit;

namespace riv4lz.casterApi.test.Controllers;

public class ProfileControllerTest
{
    private readonly ProfileController _controller;
    private readonly ControllerInfoHelper<ProfileController> _infoHelper;

    public ProfileControllerTest()
    {
        _controller = new ProfileController();
        _infoHelper = new ControllerInfoHelper<ProfileController>(_controller);
    }
    
    [Fact]
    public void ProfileController_CanBeInitialized()
    {
        Assert.NotNull(_controller);
    }
    
    [Fact]
    public void ProfileController_IsOfTypeControllerBase()
    {
        Assert.IsAssignableFrom<ControllerBase>(_controller);
    }
    
    [Fact]
    public void ProfileController_IsOfTypeBaseController()
    {
        Assert.IsAssignableFrom<BaseController>(_controller);
    }
    
    [Fact]
    public void ProfileController_IsOfTypeICasterController()
    {
        Assert.IsAssignableFrom<IProfileController>(_controller);
    }

    [Fact]
    public void ProfileController_UsesApiControllerAttribute()
    {
        var attr = _infoHelper.GetControllerAttributeByName("ApiControllerAttribute");
        
        Assert.NotNull(attr);
    }

    [Fact]
    public void ProfileController_UsesRouteAttribute()
    {
        var attr = _infoHelper.GetControllerAttributeByName("RouteAttribute");
        
        Assert.NotNull(attr);
    }
    
    [Fact]
    public void ProfileController_UsesRouteAttribute_WithParamApiControllerNameRoute()
    {
        var template = _infoHelper.GetControllerAttributeTemplate("RouteAttribute");
        
        Assert.Equal("api/[controller]", template);
    }

    #region GetProfile()

    [Fact]
    public void ProfileController_HasGetCasterProfileMethod()
    {
        var method = _infoHelper.GetMethodByName("GetProfile");
        
        Assert.NotNull(method);
    }
    
    [Fact]
    public void CasterController_GetCasterProfileMethod_ReturnsTaskOfActionResultProfileDto()
    {
        var method = _infoHelper.GetMethodByName("GetProfile");
        
        Assert.Equal(typeof(Task<ActionResult<ProfileDto>>), method.ReturnType);
    }
    
    [Fact]
    public void AuthController_GetCasterProfileMethod_IsPublic()
    {
        var method = _infoHelper.GetMethodByName("GetProfile");
        
        Assert.True(method.IsPublic);
    }

    #endregion

    #region GetProfiles()

    [Fact]
    public void ProfileController_HasGetProfilesMethod()
    {
        var method = _infoHelper.GetMethodByName("GetProfiles");
        
        Assert.NotNull(method);
    }
    
    [Fact]
    public void ProfileController_GetProfilesMethod_IsPublic()
    {
        var method = _infoHelper.GetMethodByName("GetProfiles");
        
        Assert.True(method.IsPublic);
    }

    [Fact]
    public void ProfileController_GetEventsMethod_ReturnsTaskOfActionResult_ListOfProfileDto()
    {
        var method = _infoHelper.GetMethodByName("GetProfiles");
        
        Assert.Equal(typeof(Task<ActionResult<List<ProfileDto>>>).FullName, method.ReturnType.FullName);
    }
    
    [Fact]
    public void ProfileController_GetEventsMethod_HasHttpGetAttribute()
    {
        var method = _infoHelper.GetMethodByName("GetProfiles");

        Assert.NotNull(method.GetCustomAttribute<HttpGetAttribute>());
    }
    
    [Fact]
    public void ProfileController_GetEventsMethod_DoesNotAllowAnonymous()
    {
        var method = _infoHelper.GetMethodByName("GetProfiles");
        
        Assert.False(method.GetCustomAttribute<AllowAnonymousAttribute>() != null);
    }
    
    [Fact]
    public void ProfileController_GetProfilesMethod_TakesUserTypeAsParameter()
    {
        var method = _infoHelper.GetMethodByName("GetProfiles");
        
        Assert.Equal(typeof(UserType), method.GetParameters()[0].ParameterType);
    }

    #endregion

    #region RegisterProfile()

    [Fact]
    public void ProfileController_HasRegisterProfileMethod()
    {
        var method = _infoHelper.GetMethodByName("RegisterProfile");
        
        Assert.NotNull(method);
    }
    
    [Fact]
    public void ProfileController_RegisterProfileMethod_IsPublic()
    {
        var method = _infoHelper.GetMethodByName("RegisterProfile");
        
        Assert.True(method.IsPublic);
    }

    [Fact]
    public void ProfileController_RegisterProfileMethod_ReturnsTaskOfActionResult_ProfileDto()
    {
        var method = _infoHelper.GetMethodByName("RegisterProfile");
        
        Assert.Equal(typeof(Task<ActionResult<ProfileDto>>).FullName, method.ReturnType.FullName);
    }
    
    [Fact]
    public void ProfileController_RegisterProfileMethod_HasHttpPostAttribute()
    {
        var method = _infoHelper.GetMethodByName("RegisterProfile");

        Assert.NotNull(method.GetCustomAttribute<HttpPostAttribute>());
    }
    
    [Fact]
    public void ProfileController_RegisterProfileMethod_DoesNotAllowAnonymous()
    {
        var method = _infoHelper.GetMethodByName("RegisterProfile");
        
        Assert.False(method.GetCustomAttribute<AllowAnonymousAttribute>() != null);
    }
    
    [Fact]
    public void ProfileController_RegisterProfileMethod_TakesRegisterProfileDtoAsParameter()
    {
        var method = _infoHelper.GetMethodByName("RegisterProfile");
        
        Assert.Equal(typeof(RegisterProfileDto).FullName, method.GetParameters()[0].ParameterType.FullName);
    }

    #endregion

    #region UpdateProfile()

    [Fact]
    public void ProfileController_HasUpdateProfileMethod()
    {
        var method = _infoHelper.GetMethodByName("UpdateProfile");
        
        Assert.NotNull(method);
    }
    
    [Fact]
    public void ProfileController_UpdateProfileMethod_IsPublic()
    {
        var method = _infoHelper.GetMethodByName("UpdateProfile");
        
        Assert.True(method.IsPublic);
    }

    [Fact]
    public void ProfileController_UpdateProfileMethod_ReturnsTaskOfActionResult()
    {
        var method = _infoHelper.GetMethodByName("UpdateProfile");
        
        Assert.Equal(typeof(Task<ActionResult>).FullName, method.ReturnType.FullName);
    }
    
    [Fact]
    public void ProfileController_UpdateProfileMethod_HasHttpPutAttribute()
    {
        var method = _infoHelper.GetMethodByName("UpdateProfile");

        Assert.NotNull(method.GetCustomAttribute<HttpPutAttribute>());
    }
    
    [Fact]
    public void ProfileController_UpdateProfileMethod_DoesNotAllowAnonymous()
    {
        var method = _infoHelper.GetMethodByName("UpdateProfile");
        
        Assert.False(method.GetCustomAttribute<AllowAnonymousAttribute>() != null);
    }

    [Fact]
    public void ProfileController_UpdateProfileMethod_TakesUpdateProfileDtoAsFirstParameter()
    {
        var method = _infoHelper.GetMethodByName("UpdateProfile");
        
        Assert.Equal(typeof(UpdateProfileDto).FullName, method.GetParameters()[0].ParameterType.FullName);
    }

    #endregion

    #region DeleteProfile()

    [Fact]
    public void ProfileController_HasDeleteProfileMethod()
    {
        var method = _infoHelper.GetMethodByName("DeleteProfile");
        
        Assert.NotNull(method);
    }
    
    [Fact]
    public void ProfileController_DeleteProfileMethod_IsPublic()
    {
        var method = _infoHelper.GetMethodByName("DeleteProfile");
        
        Assert.True(method.IsPublic);
    }

    [Fact]
    public void ProfileController_DeleteProfileMethod_ReturnsTaskOfActionResult_Bool()
    {
        var method = _infoHelper.GetMethodByName("DeleteProfile");
        
        Assert.Equal(typeof(Task<ActionResult<bool>>).FullName, method.ReturnType.FullName);
    }
    
    [Fact]
    public void ProfileController_DeleteProfileMethod_HasHttpDeleteAttribute()
    {
        var method = _infoHelper.GetMethodByName("DeleteProfile");

        Assert.NotNull(method.GetCustomAttribute<HttpDeleteAttribute>());
    }
    
    [Fact]
    public void ProfileController_DeleteProfileMethod_DoesNotAllowAnonymous()
    {
        var method = _infoHelper.GetMethodByName("DeleteProfile");
        
        Assert.False(method.GetCustomAttribute<AllowAnonymousAttribute>() != null);
    }
    
    [Fact]
    public void ProfileController_DeleteProfileMethod_TakesGuidAsFirstParameter()
    {
        var method = _infoHelper.GetMethodByName("DeleteProfile");
        
        Assert.Equal(typeof(Guid).FullName, method.GetParameters()[0].ParameterType.FullName);
    }

    #endregion

}