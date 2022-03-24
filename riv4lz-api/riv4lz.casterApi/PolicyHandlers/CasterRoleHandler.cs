using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace riv4lz.casterApi.PolicyHandlers;

public class RoleRequirement : IAuthorizationRequirement
{
    public string _roleName { get; set; }

    public RoleRequirement()
    {
        _roleName = "Caster";
    }
}

public class CasterRoleRequirementHandler : AuthorizationHandler<RoleRequirement>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, RoleRequirement requirement)
    {
           
        var userId = context.User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (userId != null)
        {
            var defaultContext = context.Resource as DefaultHttpContext;
            if (defaultContext != null)
            {
                var userManager = defaultContext.HttpContext.RequestServices
                    .GetRequiredService<UserManager<IdentityUser<Guid>>>();
                var user = userManager.FindByIdAsync(userId).Result;
                var roles = userManager.GetRolesAsync(user).Result;
                //if (roles.Contains(requirement._roleName))
                if (roles.Contains("Caster"))
                {
                    context.Succeed(requirement);
                    return Task.CompletedTask;
                }
                else
                {
                    context.Fail();
                }
            }
        }
        return Task.CompletedTask;
    }
}
