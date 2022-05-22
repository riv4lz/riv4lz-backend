using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using riv4lz.casterApi.Controllers;
using riv4lz.casterApi.Interfaces;
using riv4lz.casterApi.test.Helpers;
using riv4lz.Mediator.Dtos.Events;
using Xunit;

namespace riv4lz.casterApi.test.Controllers;

public class EventControllerTest
{
    private readonly EventController _controller;
    private readonly ControllerInfoHelper<EventController> _infoHelper;
    public EventControllerTest()
    {
        _controller = new EventController();
        _infoHelper = new ControllerInfoHelper<EventController>(_controller);
    }
    
    [Fact]
    public void EventController_CanBeInitialized()
    {
        Assert.NotNull(_controller);
    }
    
    [Fact]
    public void EventController_IsAssignableToControllerBase()
    {
        Assert.IsAssignableFrom<ControllerBase>(_controller);
    }
    
    [Fact]
    public void EventController_IsAssignableFromBaseController()
    {
        Assert.IsAssignableFrom<BaseController>(_controller);
    }
    
    [Fact]
    public void EventController_IsAssignableFromIEventController()
    {
        Assert.IsAssignableFrom<IEventController>(_controller);
    }
    
    [Fact]
    public void EventController_UsesRouteAttribute()
    {
        var attr = _infoHelper.GetControllerAttributeByName("RouteAttribute");
        
        Assert.NotNull(attr);
    }
    
    [Fact]
    public void EventController_UsesRouteAttribute_WithParamApiControllerNameRoute()
    {
        var template = _infoHelper.GetControllerAttributeTemplate("RouteAttribute");
        
        Assert.Equal("api/[controller]", template);
    }

    #region GetEvent()

    [Fact]
    public void EventController_HasGetEventMethod()
    {
        var method = _infoHelper.GetMethodByName("GetEvent");
        
        Assert.NotNull(method);
    }
    
    [Fact]
    public void EventController_GetEventMethod_IsPublic()
    {
        var method = _infoHelper.GetMethodByName("GetEvent");
        
        Assert.True(method.IsPublic);
    }

    [Fact]
    public void EventController_GetEventMethod_ReturnsTaskIfActionResult_EventDto()
    {
        var method = _infoHelper.GetMethodByName("GetEvent");
        
        Assert.Equal(typeof(Task<ActionResult<EventDto>>).FullName, method.ReturnType.FullName);
    }
    
    [Fact]
    public void EventController_GetEventMethod_HasHttpGetAttribute()
    {
        var method = _infoHelper.GetMethodByName("GetEvent");

        Assert.NotNull(method.GetCustomAttribute<HttpGetAttribute>());
    }
    
    [Fact]
    public void EventController_GetEventMethod_DoesNotAllowAnonymous()
    {
        var method = _infoHelper.GetMethodByName("GetEvent");
        
        Assert.False(method.GetCustomAttribute<AllowAnonymousAttribute>() != null);
    }
    
    [Fact]
    public void EventController_GetEventMethod_TakesGuidAsParameter()
    {
        var method = _infoHelper.GetMethodByName("GetEvent");
        
        Assert.Equal(typeof(Guid).FullName, method.GetParameters()[0].ParameterType.FullName);
    }
    

    #endregion

    #region GetEvents()

    [Fact]
    public void EventController_HasGetEventsMethod()
    {
        var method = _infoHelper.GetMethodByName("GetEvents");
        
        Assert.NotNull(method);
    }
    
    [Fact]
    public void EventController_GetEventsMethod_IsPublic()
    {
        var method = _infoHelper.GetMethodByName("GetEvents");
        
        Assert.True(method.IsPublic);
    }

    [Fact]
    public void EventController_GetEventsMethod_ReturnsTaskOfActionResult_ListOfEventDto()
    {
        var method = _infoHelper.GetMethodByName("GetEvents");
        
        Assert.Equal(typeof(Task<ActionResult<List<EventDto>>>).FullName, method.ReturnType.FullName);
    }
    
    [Fact]
    public void EventController_GetEventsMethod_HasHttpGetAttribute()
    {
        var method = _infoHelper.GetMethodByName("GetEvents");

        Assert.NotNull(method.GetCustomAttribute<HttpGetAttribute>());
    }
    
    [Fact]
    public void EventController_GetEventsMethod_DoesNotAllowAnonymous()
    {
        var method = _infoHelper.GetMethodByName("GetEvents");
        
        Assert.False(method.GetCustomAttribute<AllowAnonymousAttribute>() != null);
    }
    
    [Fact]
    public void EventController_GetEventsMethod_TakesNoParameters()
    {
        var method = _infoHelper.GetMethodByName("GetEvents");
        
        Assert.Empty(method.GetParameters());
        
    }
    #endregion

    #region CreateEvent()

    [Fact]
    public void EventController_HasCreateEventMethod()
    {
        var method = _infoHelper.GetMethodByName("CreateEvent");
        
        Assert.NotNull(method);
    }
    
    [Fact]
    public void EventController_CreateEventMethod_IsPublic()
    {
        var method = _infoHelper.GetMethodByName("CreateEvent");
        
        Assert.True(method.IsPublic);
    }

    [Fact]
    public void EventController_CreateEventMethod_ReturnsTaskOfActionResult_Bool()
    {
        var method = _infoHelper.GetMethodByName("CreateEvent");
        
        Assert.Equal(typeof(Task<ActionResult<bool>>).FullName, method.ReturnType.FullName);
    }
    
    [Fact]
    public void EventController_CreateEventMethod_HasHttpPostAttribute()
    {
        var method = _infoHelper.GetMethodByName("CreateEvent");

        Assert.NotNull(method.GetCustomAttribute<HttpPostAttribute>());
    }
    
    [Fact]
    public void EventController_CreateEventMethod_DoesNotAllowAnonymous()
    {
        var method = _infoHelper.GetMethodByName("CreateEvent");
        
        Assert.False(method.GetCustomAttribute<AllowAnonymousAttribute>() != null);
    }
    
    [Fact]
    public void EventController_CreateEventMethod_TakesCreateEventDtoAsParameter()
    {
        var method = _infoHelper.GetMethodByName("CreateEvent");
        
        Assert.Equal(typeof(CreateEventDto).FullName, method.GetParameters()[0].ParameterType.FullName);
    }

    #endregion

    #region UpdateEvent()

    [Fact]
    public void EventController_HasUpdateEventMethod()
    {
        var method = _infoHelper.GetMethodByName("UpdateEvent");
        
        Assert.NotNull(method);
    }
    
    [Fact]
    public void EventController_UpdateEventMethod_IsPublic()
    {
        var method = _infoHelper.GetMethodByName("UpdateEvent");
        
        Assert.True(method.IsPublic);
    }

    [Fact]
    public void EventController_UpdateEventMethod_ReturnsTaskOfActionResult_Bool()
    {
        var method = _infoHelper.GetMethodByName("UpdateEvent");
        
        Assert.Equal(typeof(Task<ActionResult<bool>>).FullName, method.ReturnType.FullName);
    }
    
    [Fact]
    public void EventController_UpdateEventMethod_HasHttpPutAttribute()
    {
        var method = _infoHelper.GetMethodByName("UpdateEvent");

        Assert.NotNull(method.GetCustomAttribute<HttpPutAttribute>());
    }
    
    [Fact]
    public void EventController_UpdateEventMethod_DoesNotAllowAnonymous()
    {
        var method = _infoHelper.GetMethodByName("UpdateEvent");
        
        Assert.False(method.GetCustomAttribute<AllowAnonymousAttribute>() != null);
    }
    
    [Fact]
    public void EventController_UpdateEventMethod_TakesGuidAsFirstParameter()
    {
        var method = _infoHelper.GetMethodByName("UpdateEvent");
        
        Assert.Equal(typeof(Guid).FullName, method.GetParameters()[0].ParameterType.FullName);
    }
    
    [Fact]
    public void EventController_UpdateEventMethod_TakesUpdateEventDtoAsSecondParameter()
    {
        var method = _infoHelper.GetMethodByName("UpdateEvent");
        
        Assert.Equal(typeof(UpdateEventDto).FullName, method.GetParameters()[1].ParameterType.FullName);
    }

    #endregion

    #region DeleteEvent()

    [Fact]
    public void EventController_HasDeleteEventMethod()
    {
        var method = _infoHelper.GetMethodByName("DeleteEvent");
        
        Assert.NotNull(method);
    }
    
    [Fact]
    public void EventController_DeleteEventMethod_IsPublic()
    {
        var method = _infoHelper.GetMethodByName("DeleteEvent");
        
        Assert.True(method.IsPublic);
    }

    [Fact]
    public void EventController_DeleteEventMethod_ReturnsTaskOfActionResult_Bool()
    {
        var method = _infoHelper.GetMethodByName("DeleteEvent");
        
        Assert.Equal(typeof(Task<ActionResult<bool>>).FullName, method.ReturnType.FullName);
    }
    
    [Fact]
    public void EventController_DeleteEventMethod_HasHttpDeleteAttribute()
    {
        var method = _infoHelper.GetMethodByName("DeleteEvent");

        Assert.NotNull(method.GetCustomAttribute<HttpDeleteAttribute>());
    }
    
    [Fact]
    public void EventController_DeleteEventMethod_DoesNotAllowAnonymous()
    {
        var method = _infoHelper.GetMethodByName("DeleteEvent");
        
        Assert.False(method.GetCustomAttribute<AllowAnonymousAttribute>() != null);
    }
    
    [Fact]
    public void EventController_DeleteEventMethod_TakesEventDtoAsFirstParameter()
    {
        var method = _infoHelper.GetMethodByName("DeleteEvent");
        
        Assert.Equal(typeof(EventDto).FullName, method.GetParameters()[0].ParameterType.FullName);
    }

    #endregion

    #region GetTeam()

    [Fact]
    public void EventController_HasGetTeamsMethod()
    {
        var method = _infoHelper.GetMethodByName("GetTeams");
        
        Assert.NotNull(method);
    }
    
    [Fact]
    public void EventController_GetTeamsMethod_IsPublic()
    {
        var method = _infoHelper.GetMethodByName("GetTeams");
        
        Assert.True(method.IsPublic);
    }

    [Fact]
    public void EventController_GetTeamsMethod_ReturnsTaskOfActionResult_ListOfTeamDto()
    {
        var method = _infoHelper.GetMethodByName("GetTeams");
        
        Assert.Equal(typeof(Task<ActionResult<List<TeamDto>>>).FullName, method.ReturnType.FullName);
    }
    
    [Fact]
    public void EventController_GetTeamsMethod_HasHttpGetAttribute()
    {
        var method = _infoHelper.GetMethodByName("GetTeams");

        Assert.NotNull(method.GetCustomAttribute<HttpGetAttribute>());
    }
    
    [Fact]
    public void EventController_GetTeamsMethod_DoesNotAllowAnonymous()
    {
        var method = _infoHelper.GetMethodByName("GetTeams");
        
        Assert.False(method.GetCustomAttribute<AllowAnonymousAttribute>() != null);
    }
    
    [Fact]
    public void EventController_GetTeamsMethod_TakesNoParameters()
    {
        var method = _infoHelper.GetMethodByName("GetTeams");
        
        Assert.Empty(method.GetParameters());
        
    }

    #endregion
    
}