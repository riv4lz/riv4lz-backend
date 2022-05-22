using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using riv4lz.casterApi.Controllers;
using riv4lz.casterApi.Interfaces;
using riv4lz.casterApi.test.Helpers;
using riv4lz.Mediator.Dtos.Profile;
using Xunit;

namespace riv4lz.casterApi.test.Controllers;

public class ImageControllerTest
{
    private readonly ImageController _controller;
    private readonly ControllerInfoHelper<ImageController> _infoHelper;

    public ImageControllerTest()
    {
        _controller = new ImageController();
        _infoHelper = new ControllerInfoHelper<ImageController>(_controller);
    }
    
    [Fact]
    public void ImageController_CanBeInitialized()
    {
        Assert.NotNull(_controller);
    }
    
    [Fact]
    public void ImageController_IsAssignableFromControllerBase()
    {
        Assert.IsAssignableFrom<ControllerBase>(_controller);
    }
    
    [Fact]
    public void ImageController_IsAssignableFromBaseController()
    {
        Assert.IsAssignableFrom<BaseController>(_controller);
    }
    
    [Fact]
    public void ImageController_IsOfTypeIImageController()
    {
        Assert.IsAssignableFrom<IImageController>(_controller);
    }
    
    [Fact]
    public void ImageController_UsesRouteAttribute()
    {
        var attr = _infoHelper.GetControllerAttributeByName("RouteAttribute");
        
        Assert.NotNull(attr);
    }
    
    [Fact]
    public void ImageController_UsesRouteAttribute_WithParamApiControllerNameRoute()
    {
        var template = _infoHelper.GetControllerAttributeTemplate("RouteAttribute");
        
        Assert.Equal("api/[controller]", template);
    }
    
    [Fact]
    public void ImageController_HasUploadImageUrlMethod()
    {
        var method = _infoHelper.GetMethodByName("UploadImageUrl");
        
        Assert.NotNull(method);
    }
    
    [Fact]
    public void ImageController_UploadImageUrl_IsPublic()
    {
        var method = _infoHelper.GetMethodByName("UploadImageUrl");
        
        Assert.True(method.IsPublic);
    }
    
    [Fact]
    public void EventController_GetEventsMethod_ReturnsTaskOfActionResult_ListOfEventDto()
    {
        var method = _infoHelper.GetMethodByName("UploadImageUrl");
        
        Assert.Equal(typeof(Task<ActionResult<bool>>).FullName, method.ReturnType.FullName);
    }
    
    [Fact]
    public void ImageController_UploadImageUrlMethod_TakesUploadImageUrlDtoAsParameter()
    {
        var method = _infoHelper.GetMethodByName("UploadImageUrl");
        
        Assert.Equal(typeof(UploadImageUrlDto).FullName, method.GetParameters()[0].ParameterType.FullName);
    }
    
    [Fact]
    public void ImageController_UploadImageUrlMethod_HasHttpPostAttribute()
    {
        var method = _infoHelper.GetMethodByName("UploadImageUrl");
        
        Assert.IsAssignableFrom<HttpPostAttribute>(method.GetCustomAttribute<HttpPostAttribute>());
    }
    
}