using System;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;

namespace riv4lz.casterApi.test.Helpers;

public class ControllerInfoHelper<T> where T : ControllerBase
{
    private readonly T _controller;
    private readonly TypeInfo _typeInfo;

    public ControllerInfoHelper(T controller)
    {
        _controller = controller;
        _typeInfo = typeof(T).GetTypeInfo();
    }
    
    
    public MethodInfo GetMethodByName(string methodName)
    {
        return typeof(T).GetMethods()
            .FirstOrDefault(m => methodName.Equals(m.Name));

    }

    public Attribute GetControllerAttributeByName(string attrName)
    {
        return _typeInfo.GetCustomAttributes().FirstOrDefault(
                a => a.GetType().Name.Equals(attrName));
    }

    public string GetControllerAttributeTemplate(string attrName)
    {
        var attr = GetControllerAttributeByName(attrName);
        var routeAttr = attr as RouteAttribute;

        return routeAttr.Template;
    }

    public CustomAttributeData GetCustomAttributeDataFromMethod(string methodName, string attrName)
    {
        return GetMethodByName(methodName).CustomAttributes
            .FirstOrDefault(ca => ca.AttributeType.Name == attrName);
    }
}